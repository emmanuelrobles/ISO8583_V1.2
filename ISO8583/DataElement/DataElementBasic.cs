using ISO8583.DataElement.Interfaces;

namespace ISO8583.DataElement
{
    public class DataElementBasic: IDataElementBasic
    {
        public virtual int? Length { get; set; }
        public virtual DATA_TYPE DataType { get; set; }
        public virtual LENGTH_TYPE LengthType { get; set; }
        public virtual string Value { get; set; }
    }
}