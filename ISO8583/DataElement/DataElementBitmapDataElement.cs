using ISO8583.DataElement.Interfaces.DataElementBitmap;

namespace ISO8583.DataElement
{
    public class DataElementBitmapDataElement : IDataElementBitmapDataElement
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        public string Value { get; set; }
    }
}