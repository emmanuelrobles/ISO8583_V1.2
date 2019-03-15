using System.Collections.Generic;
using ISO8583.DataElement;
using ISO8583.DataElement.Interfaces;

namespace ISO8583.Maps.Interface
{
    public interface IMap
    {
        IDictionary<short, IDataElementBasic> Map { get; }
        
        IDataElementBasic this[short bit] { get; }
    }
}