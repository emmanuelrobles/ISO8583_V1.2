using ISO8583.DataElement.Interfaces;

namespace ISO8583.DataElement
{
    public class SubElement : ISubDataElement
    {
        public string Value { get; set; }
        public int[] Range { get; set; }
    }
}