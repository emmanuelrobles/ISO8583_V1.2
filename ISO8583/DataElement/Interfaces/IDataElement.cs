using ISO8583.DataElement.Interfaces.DataElementRange;

namespace ISO8583.DataElement.Interfaces
{
    public interface IDataElementBasic
    {
        //basic things that is given in a Field
        int? Length { get; set; }
        DATA_TYPE DataType { get;  }
        LENGTH_TYPE LengthType { get; }
        
        string Value { get; set; }
    }
}