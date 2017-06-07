using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusDecode
{
    class MdbusFloat
    {
        public float Value { get; set; }
        public string RawString { get; set; }
        public string FloatString { get; set; }

        // User-defined conversion from MdbusFloat to float 
        public static implicit operator float(MdbusFloat mf)
        {
            return mf.Value;
        }
        //  User-defined conversion from float to MdbusFloat 
        public static implicit operator MdbusFloat(float f)
        {
            return new MdbusFloat() { Value = f};
        }
    }

    enum ModbusMessageMode
    {
        Slave,
        Master
    }
    enum ModbusMessageType
    {
        Unknown,
        Transmit,
        Receive
    }

    enum ModbusMessageRole
    {
        Request,
        Response
    }

    class MdbusMessage
    {
        public ModbusMessageMode MessageMode { get; private set; }
        public ModbusMessageType MessageType { get; private set; }
        public ModbusMessageRole MessageRole { get; private set; }
        public int SlaveId { get; private set; }
        public int FunctionCode { get; private set; }
        public int? StartAddress { get; private set; }
        public int? RegisterCount { get; private set; }
        public int? SingleRegisterValue { get; private set; }
        public int? ByteCount { get; private set; }
        public int? CoilCount { get; private set; }
        public string Checksum { get; set; }
        public List<int> Coils { get; private set; }
        public List<MdbusFloat> FloatValues { get; private set; }
        public string OriginalMessageString { get; private set; }
        public bool ChecksumOk { get; private set; }
        public bool ModbusException { get; private set; }
        public short ExceptionCode { get; private set; }

        // Declare Modbus register base addresses as consts.
        // They are all off by 1, so reading Analog Input register 100 will
        // readd address 30101.
        public static readonly int ModbusCoilBaseAddress = 1;
        public static readonly int ModbusContactsBaseAddress = 10001;
        public static readonly int ModbusInputRegisterBaseAddress = 30001;
        public static readonly int ModbusHoldingRegisterBaseAddress = 40001;

        public MdbusMessage()
        {
            FloatValues = new List<MdbusFloat>();
            Coils = new List<int>();
        }

        public static MdbusMessage Decode(string message)
        {
            return MdbusMessage.Decode(message, true, ModbusMessageMode.Slave);
        }

        public static MdbusMessage Decode(string message, bool modiconFloat)
        {
            return MdbusMessage.Decode(message, modiconFloat, ModbusMessageMode.Slave);
        }

        public static MdbusMessage Decode(string message, bool modiconFloat, ModbusMessageMode mode)
        {
            MdbusMessage mdbusMessage = new MdbusMessage();
            mdbusMessage.DecodeMessage(message, modiconFloat, mode);
            return mdbusMessage;
        }

        /// <summary>
        /// Decodes a message string from Mdbus.exe (Calta Software)
        /// </summary>
        /// <param name="message">Message string from Mdbus Monitor logging, starting with the Slave ID</param>
        /// <param name="modiconFloat">True if Modicon Float is used (the least significant bytes are sent in the first register and the most significant bytes in the second register of a pair)</param>
        /// <param name="mode">Set the mode to Master or Slave. Used to distinguish between request and response when decoding</param>
        /// <example>
        /// 
        /// Example responses:
        /// 
        /// 3 (0x03) Read Holding Registers
        /// SlaveID=1, FC=0x03, ByteCount=0x10 (16), values: 60 3A 46 ....
        /// 01 03 10 60 3A 46 33 69 89 44 57 33 CE 43 06 8B 59 3B 72 C4 8E 
        /// 
        /// 4 (0x04) Read Input Registers
        /// SlaveID=1, FC=0x04, ByteCount=0x10 (16), values: 60 3A 46 ....
        /// 01 04 10 60 3A 46 33 69 89 44 57 33 CE 43 06 8B 59 3B 72 C4 8E 
        /// 
        /// 16 (0x10) Write Multiple Registers 
        /// SlaveID=1, FC=0x10 (16), StartAddr=0x0064 (100), Registers=0x0032 (50), ByteCount=0x64 (100), Values:48 9C 1C ...
        /// 01 10 00 64 00 32 64 48 9C 1C B6 48 94 27 C8 48 98 95 47 48 87 F7 BD 42 AC 07 2B 42 AE 57 91 42 AC 89 5E 42 AF DE 29 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 45 C9 F0 4D 45 CA 95 4D 45 C9 23 FE 45 C9 64 DF 42 0A 66 66 42 0C CC CD 42 13 33 33 42 11 33 33 42 9E CC CD 9D A4 
        /// </example>
        /// <returns></returns>
        /// 
        private void DecodeMessage(string message, bool modiconFloat, ModbusMessageMode mode)
        {
            if (!message.Contains(' '))
            {
                // TODO: create string array from text without spaces.
                throw new ArgumentException("Given message string does not contain spaces. Must use a valid string from Mdbus Monitor log");
            }
            OriginalMessageString = message;
            MessageMode = mode;
            // Check if there are RX or TX in beginning
            MessageType = ModbusMessageType.Unknown;
            if (message.Trim().StartsWith("RX"))
            {
                MessageType = ModbusMessageType.Receive;
                message = message.Replace("RX", "");
            }
            else if (message.Trim().StartsWith("TX"))
            {
                MessageType = ModbusMessageType.Transmit;
                message = message.Replace("TX", "");
            }
            // If we are slave then a TX would be a request (from master) and RX would be a response
            // If we are master, then a TX would be a request (from us) and RX would be a response
            // By default we want to decode as response (we are slave and RX message is important)
            MessageRole = ModbusMessageRole.Response;
            if (MessageMode == ModbusMessageMode.Master && MessageType == ModbusMessageType.Transmit)
            {
                MessageRole = ModbusMessageRole.Request;
            }
            else if (MessageMode == ModbusMessageMode.Slave && MessageType == ModbusMessageType.Receive)
            {
                MessageRole = ModbusMessageRole.Request;
            }

            string[] hexValuesSplit = message.Trim().Split(' ');

            if (hexValuesSplit.Length > 0)
            {
                SlaveId = Convert.ToInt32(hexValuesSplit[0], 16);
            }
            if (hexValuesSplit.Length > 1)
            {
                var byteValue = Convert.ToInt16(hexValuesSplit[1], 16);
                FunctionCode = byteValue & 0x7F;                // Ignore the first (error) bit
                ModbusException = ((byteValue & 0x80) == 0x80);           // Use the first (error) bit
                if (ModbusException && (hexValuesSplit.Length > 2))
                {
                    ExceptionCode = Convert.ToInt16(hexValuesSplit[2], 16);
                }
            }

            if (hexValuesSplit.Length > 1)
            {
                Checksum = hexValuesSplit[hexValuesSplit.Length - 2] + hexValuesSplit[hexValuesSplit.Length - 1];
                ChecksumOk = ModbusUtility.CheckModbusCRC(hexValuesSplit);
            }

            
            int startByte = 0;
            bool hasDataValues = false;
            switch (FunctionCode)
            {
                case 1:
                case 2:
                    if (MessageRole == ModbusMessageRole.Request)
                    {
                        StartAddress = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 2);
                        CoilCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 4, 2);
                    }
                    else
                    {
                        ByteCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 1);
                        startByte = 3;
                    }
                    break;
                case 3:
                case 4:
                    // Request and response differs (we are slave):
                    // RX 01 03 00 00 00 2C 44 17
                    // TX 01 03 58 01 14 00 00 46 81 38 00 45 48 40 00 44 F1 80 00 42 47 99 9A 47 26 C9 00 47 1D 38 00 47 1D 3A 00 47 27 F8 00 43 82 F3 33 3F B3 33 33 43 2C 66 66 00 00 00 00 00 00 00 00 00 00 00 00 45 34 50 00 00 00 00 00 00 00 00 00 00 00 00 00 43 C9 80 00 41 49 99 9A 41 48 00 00 60 34 
                    if (MessageRole == ModbusMessageRole.Response)
                    {
                        ByteCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 1);
                        startByte = 3;
                        hasDataValues = true;
                    }
                    else
                    {
                        StartAddress = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 2);
                        RegisterCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 4, 2);
                    }

                    break;
                case 6:
                    // Request and response are the same:
                    // RX 01 06 00 00 02 FD 49 2B
                    // TX 01 06 00 00 02 FD 49 2B
                    StartAddress = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 2);
                    SingleRegisterValue = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 4, 2);                   
                    startByte = 6;
                    hasDataValues = true;
                    break;
                case 16:
                    // Request and response differs (we are slave):
                    // RX 01 10 00 5B 00 10 20 00 00 3F 80 00 00 3F 80 CC CD 42 0C CC CD 41 DC 51 EC 41 2C 1E B8 40 B5 CC CD 40 F4 E1 48 40 FA FB DB 
                    // TX 01 10 00 5B 00 10 B0 16 
                    StartAddress = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 2, 2);
                    RegisterCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 4, 2);
                    // Only request has byte count
                    if (MessageRole == ModbusMessageRole.Request)
                    {
                        ByteCount = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, 6, 1);
                        startByte = 7;
                        hasDataValues = true;
                    }
                    break;
                default:
                    break;
            }

            if (((FunctionCode == 1) || (FunctionCode == 2)) && (MessageRole == ModbusMessageRole.Response))
            {
                for (int i = startByte; (i - startByte < ByteCount) && (i < hexValuesSplit.Length - 2); i++)
                {
                    var byteValue = ModbusUtility.ConvertHexStringToInt(hexValuesSplit, i, 1);
                    if (byteValue.HasValue)
                    {
                        Coils.Add(byteValue.Value);
                    }
                }
            }

            if (hasDataValues)
            {
                // convert all float values from hex string
                for (int i = startByte; (i - startByte < ByteCount) && (i < hexValuesSplit.Length - 3); i += 4)
                {
                    MdbusFloat mdbusFloat = new MdbusFloat();
                    mdbusFloat.RawString = hexValuesSplit[i] + ' ' + hexValuesSplit[i + 1] + ' ' + hexValuesSplit[i + 2] + ' ' + hexValuesSplit[i + 3];
                    if (modiconFloat)
                    {
                        mdbusFloat.FloatString = (hexValuesSplit[i + 2] + hexValuesSplit[i + 3] + hexValuesSplit[i + 0] + hexValuesSplit[i + 1]);
                    }
                    else
                    {
                        mdbusFloat.FloatString = (hexValuesSplit[i + 0] + hexValuesSplit[i + 1] + hexValuesSplit[i + 2] + hexValuesSplit[i + 3]);
                    }
                    // Convert hex string to float value
                    uint num = uint.Parse(mdbusFloat.FloatString, System.Globalization.NumberStyles.AllowHexSpecifier);

                    byte[] floatVals = BitConverter.GetBytes(num);
                    mdbusFloat.Value = BitConverter.ToSingle(floatVals, 0);

                    FloatValues.Add(mdbusFloat);
                }
            }
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool includeOriginalMessage)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append('-', 60).AppendLine();
            strBuilder.AppendFormat("{0:D2} (0x{0:X2}) ", FunctionCode);
            var baseAddress = 0;
            switch (FunctionCode)
            {
                case 1:
                    strBuilder.AppendLine("Read Coils");
                    break;
                case 2:
                    strBuilder.AppendLine("Read Input Status");
                    break;
                case 3:
                    strBuilder.AppendLine("Read Holding Registers");
                    baseAddress = ModbusHoldingRegisterBaseAddress;
                    break;
                case 4:
                    strBuilder.AppendLine("Read Input Registers");
                    baseAddress = ModbusInputRegisterBaseAddress;
                    break;
                case 5:
                    strBuilder.AppendLine("Force Single Coil");
                    baseAddress = ModbusCoilBaseAddress;
                    break;
                case 6:
                    strBuilder.AppendLine("Preset Single Register");
                    baseAddress = ModbusHoldingRegisterBaseAddress;
                    break;
                case 8:
                    strBuilder.AppendLine("Diagnostic");
                    break;
                case 15:
                    strBuilder.AppendLine("Write Multiple Coils");
                    baseAddress = ModbusCoilBaseAddress;
                    break;
                case 16:
                    strBuilder.AppendLine("Write Multiple Holding Registers");
                    baseAddress = ModbusHoldingRegisterBaseAddress;
                    break;
                default:
                    strBuilder.AppendLine("Unknown Function Code");
                    break;
            }
            strBuilder.Append('-', 60).AppendLine();
            if (includeOriginalMessage)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1}", "Original Message:", OriginalMessageString));
            }
            if (MessageType == ModbusMessageType.Receive)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1}", "Message Type:", "Receive"));
            }
            else if (MessageType == ModbusMessageType.Transmit)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1}", "Message Type:", "Transmit"));
            }
            if (MessageRole == ModbusMessageRole.Request)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1}", "Message Role:", "Request"));
            }
            else if (MessageRole == ModbusMessageRole.Response)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1}", "Message Role:", "Response"));
            }
            strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X2})", "Slave ID:", SlaveId));
            strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X2})", "Function Code:", FunctionCode));
            if (StartAddress.HasValue)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X4})", "Start Address:", StartAddress));
            }
            if (CoilCount.HasValue)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X4})", "Coil Count:", CoilCount));
            }
            if (RegisterCount.HasValue)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X4})", "Register Count:", RegisterCount));
            }
            if (SingleRegisterValue.HasValue)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X4})", "Single Register Value:", SingleRegisterValue));
            }
            if (ByteCount.HasValue && ByteCount > 0)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X2})", "Byte Count:", ByteCount));
            }
            strBuilder.AppendLine(string.Format("{0,-20}{1,5} ({2})", "Checksum:", Checksum, ChecksumOk ? "GOOD" : "BAD"));
            if (ModbusException)
            {
                strBuilder.AppendLine(string.Format("{0,-20}{1,5} (0x{1:X2})", "Exception Code:", ExceptionCode));
                strBuilder.AppendLine(string.Format("{0,-20}{1,5}", "Exception Text:", ModbusUtility.GetModbusExceptionName(ExceptionCode)));
            }

            if (Coils.Count > 0)
            {
                strBuilder.AppendFormat("Coil Values ({0} byte):", Coils.Count).AppendLine();
                var lineNumber = 1;
                foreach (var value in Coils)
                {
                    // I wish this could be done more elegantly in the string.Format() method, but apparently not
                    string binaryString = Convert.ToString(value, 2);
                    binaryString = binaryString.PadLeft(8, '0');
                    strBuilder.AppendLine(string.Format("{0,11} {1:D3}: 0x{2:X2} -> 0b{3}", "Byte", lineNumber++, value, binaryString));
                }
            }

            if (FloatValues.Count > 0)
            {
                strBuilder.AppendFormat("Float Values ({0}):", FloatValues.Count).AppendLine();
                var lineNumber = 1;
                var address = baseAddress + StartAddress;
                foreach (var value in FloatValues)
                {
                    if (StartAddress.HasValue)
                    {
                        strBuilder.AppendLine(string.Format("{0,10:D3} {1:D5}: {2} -> {3} -> {4}", lineNumber++, address, value.RawString, value.FloatString, value.Value));
                        address += 2;
                    }
                    else
                    {
                        strBuilder.AppendLine(string.Format("{0,10:D3}: {1} -> {2} -> {3}", lineNumber++, value.RawString, value.FloatString, value.Value));
                    }
                }
            }
            return strBuilder.ToString();
        }


    }
}
