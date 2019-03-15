using ISO8583.DataElement.Interfaces.DataElementRange;

namespace ISO8583.DataElement
{
    public class ElementRangeDataElement : IDataElementRangeDataElement
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        public string Value { get; set; }
    }
}