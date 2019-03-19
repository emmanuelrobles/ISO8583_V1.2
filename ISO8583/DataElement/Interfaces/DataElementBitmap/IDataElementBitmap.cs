using System.Collections.Generic;
using ISO8583.Bitmap.Interface;
using ISO8583.DataElement.Interfaces.DataElementRange;
using ISO8583.Maps.Interface;

namespace ISO8583.DataElement.Interfaces.DataElementBitmap
{
    
    //Incase tht the subelement has a range generate a bitmap
    public interface IDataElementBitmap : IDataElementBasic
    {
        IBitmap Bitmap_DE { get; }
        IMap Map { get; }
        int BitmapLengthBytes { get; }
        IDictionary<short, IDataElementBasic> ActiveDataElements { get; }
    }
}