using SkiaSharp;
using System;

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
            SKBitmap newBitmap = null;

            try
            {
                newBitmap = new SKBitmap(width, height);

                if (!bitmap.ScalePixels(newBitmap, SKFilterQuality.High))
                {
                    newBitmap.Dispose();
                    throw new ImageOperationException("SKBitmap.ScalePixels");
                }

                return new Image(newBitmap);
            }
            catch(Exception)
            {
                newBitmap?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Flip image.
        /// </summary>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Flipped image.</returns>
        public IImage Flip(FlipDirection direction)
        {
            SKBitmap newBitmap = null;

            try
            {
                newBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

                var sx = 1.0f;
                var sy = 1.0f;
                var px = 0.0f;
                var py = 0.0f;

                if (direction == FlipDirection.Horizontal || direction == FlipDirection.Both)
                {
                    sx = -1.0f;
                    px = bitmap.Width / 2.0f;
                }

                if (direction == FlipDirection.Vertical || direction == FlipDirection.Both)
                {
                    sy = -1.0f;
                    py = bitmap.Height / 2.0f;
                }

                using (SKCanvas canvas = new SKCanvas(newBitmap))
                {
                    canvas.Scale(sx, sy, px, py);
                    canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
                }

                return new Image(newBitmap);
            }
            catch(Exception)
            {
                newBitmap?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Rotate image by degree.
        /// </summary>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Rotated image.</returns>
        public IImage RotateInDegrees(double degrees, double x, double y)
        {
            SKBitmap newBitmap = null;

            try
            {
                newBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

                using (SKCanvas canvas = new SKCanvas(newBitmap))
                {
                    canvas.RotateDegrees((float)degrees, (float)x, (float)y);
                    canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
                }

                return new Image(newBitmap);
            }
            catch (Exception)
            {
                newBitmap?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Translate image by pixel offset.
        /// </summary>
        /// <param name="x">X coordinate pixel offset.</param>
        /// <param name="y">Y coordinate pixel offset.</param>
        /// <returns></returns>
        public IImage TranslateBy(int x, int y)
        {
            SKBitmap newBitmap = null;

            try
            {
                newBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

                using (SKCanvas canvas = new SKCanvas(newBitmap))
                {
                    canvas.Translate(x, y);
                    canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
                }

                return new Image(newBitmap);
            }
            catch (Exception)
            {
                newBitmap?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Apply blend layer.
        /// </summary>
        /// <param name="layer">Image blend layer.</param>
        /// <param name="mode">Blending mode to use when applying the blend layer.</param>
        /// <returns>Image created by applying the blend layer with the given blending mode.</returns>
        //public IImage BlendWithLayer(IImage layer, BlendMode mode = BlendMode.Normal)
        //{
        //    SKBitmap newBitmap = null;

        //    try
        //    {
        //        newBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

        //        using (SKCanvas canvas = new SKCanvas(newBitmap))
        //        {
        //            using (SKPaint paint = new SKPaint())
        //            {
        //                paint.BlendMode = SKBlendMode.Modulate;
        //                canvas.DrawBitmap(bitmap, 0.0f, 0.0f, paint);
        //            }
        //        }

        //        return new Image(newBitmap);
        //    }
        //    catch (Exception)
        //    {
        //        newBitmap?.Dispose();
        //        throw;
        //    }
        //}
    }
}
