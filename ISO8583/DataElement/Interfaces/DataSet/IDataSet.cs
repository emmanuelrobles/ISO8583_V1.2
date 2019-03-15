using System.Collections.Generic;

namespace ISO8583.DataElement.Interfaces.DataSet
{
    public interface IDataSet
    {
        int Length { get; set; }
        int Id { get; set; }
        List<ITLV> TlVs { get; set; }
    }
}