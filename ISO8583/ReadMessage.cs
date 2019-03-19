using System;
using System.Collections.Generic;
using ISO8583.Bitmap;
using ISO8583.DataElement;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementBitmap;
using ISO8583.Maps.Interface;

namespace ISO8583
{
    public class ReadMessage
    {
        private string _MTI;
        private BitmapManager _bitmapManager;
        private string _iso;
        private string _dataFields;
        private IDictionary<short, IDataElementBasic> _dataElements;

        public ReadMessage(IMap map, string iso)
        {
            //create the data elements
            _dataElements = new Dictionary<short, IDataElementBasic>();

            //create the bitmap manager
            _bitmapManager = new BitmapManager();

            //save the ISO8583 msg
            this._iso = iso;

            //get the MTI and remove it
            _MTI = iso.Substring(0, Util.MTI_LENGTH);
            iso = iso.Remove(0, Util.MTI_LENGTH);

            do
            {
                //get all bitmaps and remove them
                _bitmapManager.AddBitmap(new Bitmap.Bitmap() {BitmapHex = iso.Substring(0, Util.BTIMAP_LENGTH)});
                iso = iso.Remove(0, Util.BTIMAP_LENGTH);
            } while (_bitmapManager.HasNextBitmap());

            //save the dataFields
            this._dataFields = iso;

            _dataElements = Util.ReadFields(map, _bitmapManager.GetActiveBits(), ref iso);

            
            //trsting
            foreach (short bit in _bitmapManager.GetActiveBits())
            {
                Console.WriteLine(bit);
            }

            foreach (var a in _dataElements)
            {
                Console.WriteLine(a.Value.Value);


                if (a.Value.GetType() == typeof(DataElementBitmap))
                {
                    var dataElementBitmap = (DataElementBitmap) a.Value;
                    dataElementBitmap.BuildBitmap();
                    
                    Console.WriteLine(dataElementBitmap.Length);
                    
                    
                }
            }
        }
    }
}