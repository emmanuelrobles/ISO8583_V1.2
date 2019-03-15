using System.Collections.Generic;

namespace ISO8583.DataElement.Interfaces.DataElementRange
{
    public interface IDataElementRange : IDataElementBasic
    {
        
        short[] ActiveFields { get; set; }
        List<IDataElementRangeDataElement> SubElementRangeDataElements { get; set; }
    }
}