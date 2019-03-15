using System.Collections.Generic;
using ISO8583.DataElement.Interfaces.DataElementBitmap;
using ISO8583.DataElement.Interfaces.DataElementRange;
using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement.Interfaces
{
    public interface IDataElement : IDataElementRange, IDataElementBitmap, IDataSet
    {
        List<IDataElementBitmap> SubDataElements { get; set; }
        List<IDataSet> DataSets { get; set; }
    }

    public interface IDataElementBasic
    {
        //basic things that is given in a Field
        int? Length { get; set; }
        DATA_TYPE DataType { get; set; }
        LENGTH_TYPE LengthType { get; set; }
        
        string Value { get; set; }
    }
}