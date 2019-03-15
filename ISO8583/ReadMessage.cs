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
                iso=iso.Remove(0, Util.BTIMAP_LENGTH);
                
            } while (_bitmapManager.HasNextBitmap());

            //save the dataFields
            this._dataFields = iso;

            _dataElements = ReadFields(map, ref iso);
            
            foreach (var a in _dataElements)
            {
                Console.WriteLine(a.Value.Value);
            }
            
            
            
            
        }

        private IDictionary<short, IDataElementBasic> ReadFields(IMap map, ref string iso)
        {
            IDictionary<short, IDataElementBasic> activeValues = new Dictionary<short, IDataElementBasic>();

            foreach (var activeBit in _bitmapManager.GetActiveBits())
            {
                activeValues.Add(activeBit,ReadField(map[activeBit], ref iso));
            }


            return activeValues;
        }

        private IDataElementBasic ReadField(IDataElementBasic map,ref string iso)
        {
            int length = map.Length ?? 0;
            
            if (map.LengthType!=LENGTH_TYPE.FIX)
            {
                int tempLength = 0;
                
                switch (map.LengthType)
                {
                    case LENGTH_TYPE.LLV:
                        tempLength = 2;
                        break;
                    case LENGTH_TYPE.LLLV:
                        tempLength = 3;
                        break;
                    
                }   
                
                
                length = int.Parse(iso.Substring(0, tempLength));
                iso = iso.Remove(0, tempLength);
                    
                    
                //if length is odd and if it has a leading 0 remove it
                if (length % 2 != 0 && iso[0].Equals('0'))
                {
                    iso = iso.Remove(0, 1);
                }
                
            }

            string value = iso.Substring(0, length);
            iso = iso.Remove(0, length);


            if (map is IDataElementBitmap)
            {
                
            }
            
            
            //Testing
            DataElementBasic dataElementBasic = new DataElementBasic(){Value = value,Length = length,DataType = map.DataType,LengthType = map.LengthType};
            return dataElementBasic;
        }
        
    }
}