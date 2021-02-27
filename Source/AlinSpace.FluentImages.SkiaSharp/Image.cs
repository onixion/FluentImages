using SkiaSharp;

namespace AlinSpace.FluentImages.SkiaSharp
{
    /// <summary>
    /// Image implementation for SkiaSharp.
    /// </summary>
    public class Image : IImage
    {
        SKBitmap bitmap;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rawBytes">Image as raw bytes.</param>
        public Image(byte[] rawBytes)
        {
            bitmap = SKBitmap.Decode(rawBytes);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">SKBitmap.</param>
        public Image(SKBitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            bitmap.Dispose();
        }

        /// <summary>
        /// Width of image.
        /// </summary>
        public int Width => bitmap.Width;

        /// <summary>
        /// Height of image.
        /// </summary>
        public int Height => bitmap.Height;

        /// <summary>
        /// Import image from raw byte array.
        /// </summary>
        /// <param name="rawBytes">Image as raw byte array.</param>
        public void Import(byte[] rawBytes)
        {
            if (bitmap != null)
                bitmap.Dispose();

            bitmap = SKBitmap.Decode(rawBytes);
        }

        /// <summary>
        /// Export image to raw byte array.
        /// </summary>
        /// <param name="format">Format to encode the image to.</param>
        /// <param name="quality">Quality.</param>
        /// <returns>Byte array.</returns>
        public byte[] Export(Format format, Quality quality = Quality.Best)
        {
            return bitmap.Encode(format.ToSkiaFormat(), quality.ToSkiaQuality()).ToArray();
        }

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public IImage ResizeTo(int width, int height)
        {
            SKBitmap newBitmap = new SKBitmap(width, height);

            if (!bitmap.ScalePixels(newBitmap, SKFilterQuality.High))
            {
                newBitmap.Dispose();
                throw new ImageOperationException("SKBitmap.ScalePixels");
            }

            return new Image(newBitmap);
        }
    }
}
