namespace ISO8583.DataElement.Interfaces
{
    public interface ISubDataElement
    {
        string Value { get; set; }
        int[] Range { get; set; }
    }
}