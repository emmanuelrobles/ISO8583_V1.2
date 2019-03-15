using System;
using System.Collections.Generic;
using ISO8583.Bitmap.Interface;

namespace ISO8583.Bitmap
{
    public class Bitmap : IBitmap
    {
        public const int BITS = 64;
        public string BitmapHex { get; set; }

        public short[] GetActiveBits()
        {
           

            return Util.GetActiveBytesFromHexBitmap(BitmapHex);

        }

        public bool HasNextBitmap()
        {
            //check first element to see if it has a new bitmap
            return Util.FromHexToBinary(BitmapHex)[0].Equals('1');
        }
        
        
    }
}