namespace ISO8583.DataElement.Interfaces.DataSet
{
    public interface ITLV
    {
        string Tag { get; set; }
        int Length { get; set; }
        string Value { get; set; }
        
    }
}