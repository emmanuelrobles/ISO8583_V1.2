using System.Collections.Generic;
using ISO8583.DataElement.Interfaces.DataSet;

namespace ISO8583.DataElement.Interfaces
{
    public interface IDataElementBasic
    {
        
        //basic things that is given in a Field
        int? Length { get; set; }
        DATA_TYPE DataType { get; set; }
        LENGTH_TYPE LengthType { get; set; }

        List<ISubDataElement> SubDataElements { get; set; }
        List<IDataSet> DataSets { get; set; }
        

    }
}