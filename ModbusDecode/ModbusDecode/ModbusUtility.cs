using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModbusDecode
{
    class ModbusUtility
    {
        public static Nullable<int> ConvertHexStringToInt(string[] hexvalues, int startIndex, int count)
        {
            string hexString = string.Empty;
            if (hexvalues.Length > startIndex + count - 1)
            {
                for (int i = startIndex; i < startIndex + count; i++)
                {
                    hexString += hexvalues[i];
                }
                return Convert.ToInt32(hexString, 16);
            }
            return null;
        }

        /// <summary>
        /// Calculates the Modbus checksum (CRC) based on the code found here:
        /// http://www.ccontrolsys.com/w/How_to_Compute_the_Modbus_RTU_Message_CRC
        /// Notice that when calculating the CRC for the message including the last two bytes values (the given CRC),
        /// the result should be zero.
        /// To calculate the CRC for comarison we would have to send the message after stripping off the CRC in the end,
        /// but then the value seems to be swapped.
        /// </summary>
        /// <param name="hexValues">Array of string hex values</param>
        /// <returns>the calculated CRC value</returns>
        public static int CalculateCRC(string[] hexValues)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < hexValues.Length; pos++)
            {
                var hexValue = Convert.ToInt16(hexValues[pos], 16);
                crc ^= (UInt16)hexValue;                                // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {                                                   // If the LSB is set
                        crc >>= 1;                                      // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                                                // Else LSB is not set
                    {    
                        crc >>= 1;                                      // Just shift right
                    }
                }
            }
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            return crc;
        }

        public static bool CheckModbusCRC(string[] hexValues)
        {
            return CalculateCRC(hexValues) == 0;
        }
            

    }
}
