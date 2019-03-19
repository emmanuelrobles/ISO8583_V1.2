using System.Collections.Generic;
using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement
{
    public class DataSet :DataElementBasic, IDataSet
    {
        public int Id { get; set; }
        public IList<ITLV> TlVs { get; set; }

        public DataSet(LENGTH_TYPE lengthType, DATA_TYPE dataType, int? length = null, string value = null) : base(lengthType, dataType, length, value)
        {
        }
    }
}