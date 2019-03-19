using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISO8583.DataElement;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementBitmap;
using ISO8583.DataElement.Interfaces.DataElementRange;
using ISO8583.DataElement.Interfaces.DataSet;
using ISO8583.Maps.Interface;

namespace ISO8583
{
    public static class Util
    {
        public const byte MTI_LENGTH = 4;
        public const byte BTIMAP_LENGTH = 16;


        //ReadAllFields
        public static IDictionary<short, IDataElementBasic> ReadFields(IMap map, short[] activeBits, ref string iso,
            Dictionary<Type, Action> @switch = null)
        {
            IDictionary<short, IDataElementBasic> activeValues = new Dictionary<short, IDataElementBasic>();

            foreach (var activeBit in activeBits)
            {
                activeValues.Add(activeBit, ReadField(map[activeBit], ref iso));
            }


            return activeValues;
        }

        private static IDataElementBasic ReadField(IDataElementBasic fieldMap, ref string iso,
            Dictionary<Type, Action> @switch = null)
        {
            //get the fix length if not 0
            int length = fieldMap.Length ?? 0;

            //get the var lenght
            if (fieldMap.LengthType != LENGTH_TYPE.FIX)
            {
                int tempLength = 0;

                switch (fieldMap.LengthType)
                {
                    case LENGTH_TYPE.LLV:
                        tempLength = 2;
                        break;
                    case LENGTH_TYPE.LLLV:
                        tempLength = 3;
                        break;
                }


                length = int.Parse(iso.Substring(0, tempLength));
                iso = iso.Remove(0, tempLength);


                //if length is odd and if it has a leading 0 remove it
                if (length % 2 != 0 && iso[0].Equals('0'))
                {
                    iso = iso.Remove(0, 1);
                }
            }

            //get the value of the field
            string value = iso.Substring(0, length);
            iso = iso.Remove(0, length);

            IDataElementBasic toReturn = null;


            //parsing each element
            if (@switch == null)
            {
                @switch = new Dictionary<Type, Action>
                {
                    {typeof(DataElementBitmap), () => { toReturn = (DataElementBitmap) fieldMap; }},
                    {typeof(DataElementRange), () => { toReturn = (DataElementRange) fieldMap; }},
                    {typeof(DataElementBasic), () => toReturn = (DataElementBasic) fieldMap},
                };
            }


            @switch[fieldMap.GetType()]();


            toReturn.Value = value;
            toReturn.Length = length;

            return toReturn;
        }


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
                    activeBytes.Add((short) (i + 1));
                }
            }

            return activeBytes.ToArray();
        }
    }
}