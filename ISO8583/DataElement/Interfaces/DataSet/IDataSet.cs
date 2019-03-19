using System.Collections.Generic;

namespace ISO8583.DataElement.Interfaces.DataSet
{
    public interface IDataSet : IDataElementBasic
    {
        int Id { get; }
        IList<ITLV> TlVs { get; }
    }
}