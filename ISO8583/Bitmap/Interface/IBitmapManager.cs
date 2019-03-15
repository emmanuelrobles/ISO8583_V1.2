using System.Collections.Generic;

namespace ISO8583.Bitmap.Interface
{
    public interface IBitmapManager
    {
        List<IBitmap> Bitmaps { get; }

        bool AddBitmap(IBitmap bitmap);

        bool HasNextBitmap();

        bool RemoveBitmap(IBitmap bitmap);

        short[] GetActiveBits();

        short GetBitmapCount();
    }
}