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

    }
}