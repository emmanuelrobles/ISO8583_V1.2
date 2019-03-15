using ISO8583.DataElement.Interfaces;

namespace ISO8583.DataElement
{
    public class DataElementBasic: IDataElementBasic
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        public string Value { get; set; }
    }
}