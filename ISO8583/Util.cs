using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISO8583
{
    public static class Util
    {
        public const byte MTI_LENGTH = 4;
        public const byte BTIMAP_LENGTH = 16;

        //convert from hexadecimal to binary
        public static string FromHexToBinary(string hex)
        {
            return String.Join(String.Empty,
                hex.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                )
            );
        }
        
        //convert from binary to hexadecimal
        public static string FromBinaryToHex(string binary)
        {
            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... Will throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
        
        //get the active bits from hex
        public static short[] GetActiveBytesFromHexBitmap(string hexBitmap)
        {

            string binaryBitmap = FromHexToBinary(hexBitmap);
            
            return GetActiveBytesFromBinaryBitmap(binaryBitmap);
        }

        //get the active bytes from binary
        public static short[] GetActiveBytesFromBinaryBitmap(string binaryBitmap)
        {
            List<short> activeBytes = new List<short>();

            for (int i = 0; i < binaryBitmap.Length; i++)
            {
                if (binaryBitmap[i].Equals('1'))
                {
                    activeBytes.Add((short) (i+1));
                }
            }

            return activeBytes.ToArray();
        }
        
    }
}