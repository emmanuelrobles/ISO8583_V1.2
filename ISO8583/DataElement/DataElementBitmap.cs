using System.Collections.Generic;
using ISO8583.Bitmap.Interface;
using ISO8583.DataElement.Interfaces.DataElementBitmap;

namespace ISO8583.DataElement
{
    public class DataElementBitmap : IDataElementBitmap
    {
        public int? Length { get; set; }
        public DATA_TYPE DataType { get; set; }
        public LENGTH_TYPE LengthType { get; set; }
        public string Value { get; set; }
        public IBitmap Bitmap { get; set; }
        public List<IDataElementBitmapDataElement> SubDataElementDataElements { get; set; }
    }
}