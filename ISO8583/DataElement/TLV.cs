using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class TLV :ITLV
    {
        public string Tag { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
    }
}