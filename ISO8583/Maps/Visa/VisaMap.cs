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
                [Convert.ToInt16(2)] = new DataElementBasic(LENGTH_TYPE.LLV, DATA_TYPE.N),

                [Convert.ToInt16(3)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N, 6),

                [Convert.ToInt16(7)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N, 10),

                [Convert.ToInt16(22)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N, 4),

                [Convert.ToInt16(63)] = new DataElementBitmap(3,LENGTH_TYPE.LLV,DATA_TYPE.AN)
                    {Map =new VisaMap_63()}
            };
        }
    }


    public class VisaMap_63 : IMap
    {
        public IDictionary<short, IDataElementBasic> Map { get; }

        public IDataElementBasic this[short bit] => Map[bit];

        public VisaMap_63()
        {
            Map = new Dictionary<short, IDataElementBasic>()
            {
                [Convert.ToInt16(1)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,4),
                [Convert.ToInt16(3)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,4),
                [Convert.ToInt16(4)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,4),
                [Convert.ToInt16(6)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,7),
                [Convert.ToInt16(8)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,8),
                [Convert.ToInt16(9)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,14),
                [Convert.ToInt16(11)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,1),
                [Convert.ToInt16(12)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,30),
                [Convert.ToInt16(13)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,6),//check
                [Convert.ToInt16(14)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,36),
                [Convert.ToInt16(15)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,9),
                [Convert.ToInt16(19)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,3),
                [Convert.ToInt16(21)] = new DataElementBasic(LENGTH_TYPE.FIX, DATA_TYPE.N,1),
                
                
            };
        }
        
        
    }
}