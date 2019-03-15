using System;
using System.Collections.Generic;
using ISO8583.DataElement;
using ISO8583.DataElement.Interfaces;
using ISO8583.Maps.Interface;

namespace ISO8583.Maps.Visa
{
    public class VisaMap : IMap
    {
        public IDictionary<short, IDataElementBasic> Map { get; }

        public IDataElementBasic this[short bit] => Map[bit];

        public VisaMap()
        {
            Map = new Dictionary<short, IDataElementBasic>()
            {
                [Convert.ToInt16(2)] = new DataElementBasic() {DataType = DATA_TYPE.N, LengthType = LENGTH_TYPE.LLV},
                [Convert.ToInt16(3)] = new DataElementBasic()
                    {DataType = DATA_TYPE.N, LengthType = LENGTH_TYPE.FIX, Length = 6,},
                [Convert.ToInt16(7)] = new DataElementBasic()
                    {DataType = DATA_TYPE.N, LengthType = LENGTH_TYPE.FIX, Length = 10},
                [Convert.ToInt16(22)] = new DataElementBasic()
                    {DataType = DATA_TYPE.N, LengthType = LENGTH_TYPE.FIX, Length = 4},
                [Convert.ToInt16(63)] = new DataElementBitmap()
                {DataType = DATA_TYPE.N, LengthType = LENGTH_TYPE.LLV}
            };
        }
    }
}