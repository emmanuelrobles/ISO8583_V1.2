using System.Collections.Generic;
using ISO8583.Bitmap.Interface;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementBitmap;

namespace ISO8583.DataElement
{
    public class DataElementBitmap : DataElementBasic, IDataElementBitmap
    {
        public IBitmap Bitmap { get; set; }
        public List<IDataElementBasic> SubDataElementDataElements { get; set; }
    }
}