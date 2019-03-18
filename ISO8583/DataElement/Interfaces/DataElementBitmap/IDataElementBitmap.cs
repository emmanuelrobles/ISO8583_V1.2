using System.Collections.Generic;
using ISO8583.Bitmap.Interface;

namespace ISO8583.DataElement.Interfaces.DataElementBitmap
{
    
    //Incase tht the subelement has a range generate a bitmap
    public interface IDataElementBitmap : IDataElementBasic
    {
        IBitmap Bitmap { get; set; }
        List<IDataElementBasic> SubDataElementDataElements { get; set; }
    }
}