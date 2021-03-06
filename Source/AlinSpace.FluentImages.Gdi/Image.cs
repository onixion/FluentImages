using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace AlinSpace.FluentImages.Gdi
{
    /// <summary>
    /// Image implementation for <see cref="System.Drawing.Image"/>.
    /// </summary>
    public class Image : IImage
    {
        readonly System.Drawing.Image bitmap;

        /// <summary>
        /// Width of image.
        /// </summary>
        public int Width => bitmap.Width;

        /// <summary>
        /// Height of image.
        /// </summary>
        public int Height => bitmap.Height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public Image(Stream stream)
        {
            bitmap = System.Drawing.Image.FromStream(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rawBytes">Image as raw bytes.</param>
        public Image(byte[] rawBytes)
        {
            using var stream = new MemoryStream(rawBytes);
            bitmap = System.Drawing.Image.FromStream(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image">Image.</param>
        public Image(Image image)
        {
            bitmap = (System.Drawing.Image)image.bitmap.Clone();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">SKBitmap.</param>
        private Image(System.Drawing.Image image)
        {
            bitmap = (System.Drawing.Image)image.Clone();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            bitmap.Dispose();
        }

        /// <summary>
        /// Clone the image.
        /// </summary>
        /// <returns>Cloned image.</returns>
        public IImage Clone()
        {
            return new Image(this);
        }

        /// <summary>
        /// Export image to stream.
        /// </summary>
        /// <param name="stream">Stream to export the image to..</param>
        /// <param name="format">Format for the encoding.</param>
        /// <returns>Byte array.</returns>
        public void ExportToStream(Stream stream, Format format)
        {
            bitmap.Save(stream, format.ToGdiFormat());
        }

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public IImage ResizeTo(int width, int height)
        {
            Bitmap newBitmap = null;

            try
            {
                newBitmap = new Bitmap(width, height);
                newBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using var wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.DrawImage(
                        image: bitmap,
                        destRect: new System.Drawing.Rectangle(0, 0, width, height),
                        srcX: 0,
                        srcY: 0,
                        srcWidth: bitmap.Width,
                        srcHeight: bitmap.Height,
                        srcUnit: GraphicsUnit.Pixel,
                        imageAttr: wrapMode);
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
        /// Map image to rectangle area.
        /// </summary>
        /// <param name="rectangle">Rectangle.</param>
        /// <returns>Mapped image.</returns>
        public IImage MapTo(Rectangle rectangle)
        {
            Bitmap newBitmap = null;

            try
            {
                newBitmap = new Bitmap(Width, Height);
                newBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using var wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.DrawImage(
                        image: bitmap,
                        destRect: rectangle.ToRectangle(),
                        srcX: 0,
                        srcY: 0,
                        srcWidth: bitmap.Width,
                        srcHeight: bitmap.Height,
                        srcUnit: GraphicsUnit.Pixel,
                        imageAttr: wrapMode);
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
        /// Flip image.
        /// </summary>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Flipped image.</returns>
        public IImage Flip(FlipDirection direction)
        {
            //var newBitmap = (Bitmap)bitmap.Clone();
            //newBitmap.RotateFlip(direction.ToRotateFlipType());

            // TODO

            return this;
        }

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Rotated image.</returns>
        public IImage RotateInDegrees(double degrees, double x, double y)
        {
            Bitmap newBitmap = null;
            
            try
            {
                newBitmap = new Bitmap(Width, Height);
                newBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using var wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.TranslateTransform((float)x, (float)y);
                    graphics.RotateTransform((float)(degrees.ToPositive()));
                    graphics.TranslateTransform((float)-x, (float)-y);

                    graphics.DrawImage(
                        image: bitmap,
                        destRect: new System.Drawing.Rectangle(0, 0, Width, Height),
                        srcX: 0,
                        srcY: 0,
                        srcWidth: bitmap.Width,
                        srcHeight: bitmap.Height,
                        srcUnit: GraphicsUnit.Pixel,
                        imageAttr: wrapMode);
                }

                return new Image(newBitmap);
            }
            catch (Exception)
            {
                newBitmap?.Dispose();
                throw;
            }
        }
    }
}
