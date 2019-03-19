using System.Collections.Generic;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementRange;

namespace ISO8583.DataElement
{
    public class DataElementRange :DataElementBasic, IDataElementRange
    {
        public virtual short[] ActiveBits { get; set; }
        public virtual IDictionary<short, IDataElementBasic> ActiveDataElements { get; }

        public DataElementRange(LENGTH_TYPE lengthType, DATA_TYPE dataType, int? length = null, string value = null) : base(lengthType, dataType, length, value)
        {
        }
    }
}