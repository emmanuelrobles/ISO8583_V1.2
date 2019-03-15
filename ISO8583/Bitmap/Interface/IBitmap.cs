namespace ISO8583.Bitmap.Interface
{
    public interface IBitmap
    {
        string BitmapHex { get; set; }

        short[] GetActiveBits();

        bool HasNextBitmap();

    }
}