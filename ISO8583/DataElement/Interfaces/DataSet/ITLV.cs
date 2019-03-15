namespace ISO8583.DataElement.Interfaces.DataSet
{
    public interface ITLV : IDataElementBasic
    {
        string Tag { get; set; }
        string Value { get; set; }
        
    }
}