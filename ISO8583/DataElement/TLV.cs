using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class TLV : ITLV
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        
        public string Tag { get; set; }
        public string Value { get; set; }
    }
}