using System.Collections.Generic;
using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class DataSet : IDataSet
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
        public List<ITLV> TlVs { get; set; }
    }
}