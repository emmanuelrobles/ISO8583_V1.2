using System;
using ISO8583.DataElement.Interfaces;

namespace ISO8583.DataElement
{
    public class DataElementBasic: IDataElementBasic
    {
        public int? Length { get; set; }
        public virtual DATA_TYPE DataType { get; }
        public virtual LENGTH_TYPE LengthType { get; }
        public virtual string Value { get; set; }

        
        //delegate
        public delegate void ValueAddedHandler(string value);

        
        public DataElementBasic(LENGTH_TYPE lengthType, DATA_TYPE dataType , int? length = null, string value = null)
        {

            if (length == null && lengthType == LENGTH_TYPE.FIX)
            {
                throw new ArgumentException("If length is null Length type cannot be fix or vice versa");
            }

            LengthType = lengthType;
            Length = length;
            DataType = dataType;
            Value = value;
            
            
        }
    }
}