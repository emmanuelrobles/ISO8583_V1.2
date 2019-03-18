using System.Collections.Generic;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementRange;

namespace ISO8583.DataElement
{
    public class ElementRange :DataElementBasic, IDataElementRange
    {
        public short[] ActiveFields { get; set; }
        public List<IDataElementBasic> SubElementRangeDataElements { get; set; }
    }
}