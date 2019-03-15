using System;
using System.Collections.Generic;
using System.Linq;
using ISO8583.Bitmap.Interface;

namespace ISO8583.Bitmap
{
    public class BitmapManager : IBitmapManager
    {
        private const int BITMAP_COUNT = 3;

        public BitmapManager(List<IBitmap> bitmaps)
        {
            if (bitmaps.Count > BITMAP_COUNT)
            {
                throw new ArgumentOutOfRangeException("Max number of bitmaps is " + BITMAP_COUNT +
                                                      " ; Lenght of your List: " + bitmaps.Count);
            }

            Bitmaps = bitmaps;
        }

        public BitmapManager()
        {
            Bitmaps = new List<IBitmap>();
        }

        public List<IBitmap> Bitmaps { get; }

        public bool AddBitmap(IBitmap bitmap)
        {
            if (Bitmaps.Count > BITMAP_COUNT)
            {
                return false;
            }
            
            Bitmaps.Add(bitmap);
            return true;
        }

        public bool HasNextBitmap()
        {
            return Bitmaps.Last().HasNextBitmap();
        }

        public bool RemoveBitmap(IBitmap bitmap)
        {
            return Bitmaps.Remove(bitmap);
        }

        public short[] GetActiveBits()
        {
            //number of bits in a bitmap to add
            short temp = 0;

            List<short> allActiveBites = new List<short>();
            
            foreach (IBitmap bitmap in Bitmaps)
            {
                foreach (short activeBit in bitmap.GetActiveBits())
                {
                    allActiveBites.Add((short) (activeBit+temp));
                }

                temp += Bitmap.BITS;
            }

            return allActiveBites.ToArray();
        }

        public short GetBitmapCount()
        {
            return (short) Bitmaps.Count;
        }
    }
}