using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class TLV :DataElementBasic, ITLV
    {    
        public string Tag { get; set; }

    }
}