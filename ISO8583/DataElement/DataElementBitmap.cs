using System.Collections;
using System.Collections.Generic;
using ISO8583.Bitmap.Interface;
using ISO8583.DataElement.Interfaces;
using ISO8583.DataElement.Interfaces.DataElementBitmap;
using ISO8583.Maps.Interface;

namespace ISO8583.DataElement
{
    public class DataElementBitmap : DataElementBasic, IDataElementBitmap
    {
        public IBitmap Bitmap_DE { get; private set; }
        public IMap Map { get; set; }
        public int BitmapLengthBytes { get; }
        
        public IDictionary<short, IDataElementBasic> ActiveDataElements => GetActiveDataElement(Value);

        public void BuildBitmap()
        {
            Bitmap_DE = new Bitmap.Bitmap() {BitmapHex = Value.Substring(0, BitmapLengthBytes * 2)};
        }
        
        public DataElementBitmap(int bitmapLengthBytes, LENGTH_TYPE lengthType, DATA_TYPE dataType, int? length = null,
            string value = null) : base(lengthType, dataType, length, value)
        {
            BitmapLengthBytes = bitmapLengthBytes;
        }


        private IDictionary<short, IDataElementBasic> GetActiveDataElement(string value)
        {
            IDictionary<short, IDataElementBasic> dataElementsActive = new Dictionary<short, IDataElementBasic>();

           
            value.Remove(0, BitmapLengthBytes * 2);

            dataElementsActive = Util.ReadFields(Map, Bitmap_DE.GetActiveBits(), ref value);

            return dataElementsActive;
        }
    }
}