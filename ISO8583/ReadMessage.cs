using System;
using ISO8583.Bitmap;
using ISO8583.DataElement;
using ISO8583.DataElement.Interfaces.DataElementBitmap;
using ISO8583.Maps.Interface;

namespace ISO8583
{
    public class ReadMessage
    {
        private string _MTI;
        private BitmapManager _bitmapManager;
        
        public ReadMessage(IMap map, string iso)
        {
            _bitmapManager = new BitmapManager();


            _MTI = iso.Substring(0, Util.MTI_LENGTH);
            iso = iso.Remove(0, Util.MTI_LENGTH);

            do
            {
                _bitmapManager.AddBitmap(new Bitmap.Bitmap() {BitmapHex = iso.Substring(0, Util.BTIMAP_LENGTH)});
                iso.Remove(0, Util.BTIMAP_LENGTH);
            } while (_bitmapManager.HasNextBitmap());


            foreach (var a in map.Map)
            {
                if (a.Value is IDataElementBitmap)
                {
                    DataElementBitmap b = a.Value as DataElementBitmap;
                    Console.WriteLine(b.SubDataElementDataElements[0].DataType);
                }    
            }

        }
    }
}