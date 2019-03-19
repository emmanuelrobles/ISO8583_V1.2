using System.Collections.Generic;

namespace ISO8583.DataElement.Interfaces.DataElementRange
{
    public interface IDataElementRange : IDataElementBasic
    {
        
        short[] ActiveBits { get; }
        IDictionary<short,IDataElementBasic> ActiveDataElements { get; }
    }
}