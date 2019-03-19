using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class TLV :DataElementBasic, ITLV
    {    
        public string Tag { get; set; }

        public TLV(LENGTH_TYPE lengthType, DATA_TYPE dataType, int? length = null, string value = null) : base(lengthType, dataType, length, value)
        {
        }
    }
}