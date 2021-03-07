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
        readonly System.Drawing.Image image;

        /// <summary>
        /// Width of image.
        /// </summary>
        public int Width => image.Width;

        /// <summary>
        /// Height of image.
        /// </summary>
        public int Height => image.Height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public Image(Stream stream)
        {
            image = System.Drawing.Image.FromStream(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rawBytes">Image as raw bytes.</param>
        public Image(byte[] rawBytes)
        {
            using var stream = new MemoryStream(rawBytes);
            image = System.Drawing.Image.FromStream(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image">Image.</param>
        public Image(Image image)
        {
            this.image = (System.Drawing.Image)image.image.Clone();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">SKBitmap.</param>
        private Image(System.Drawing.Image image)
        {
            this.image = (System.Drawing.Image)image.Clone();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            image.Dispose();
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
            image.Save(stream, format.ToGdiFormat());
        }

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public IImage ResizeTo(int width, int height)
        {
            Bitmap newImage = null;

            try
            {
                newImage = new Bitmap(width, height);
                newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using var wrapMode = new ImageAttributes();
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.DrawImage(
                        image: image,
                        destRect: new System.Drawing.Rectangle(0, 0, width, height),
                        srcX: 0,
                        srcY: 0,
                        srcWidth: image.Width,
                        srcHeight: image.Height,
                        srcUnit: GraphicsUnit.Pixel,
                        imageAttr: wrapMode);
                }

                return new Image(newImage);
            }
            catch (Exception)
            {
                newImage?.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Transform image.
        /// </summary>
        /// <param name="transformFunction">Transform function.</param>
        /// <returns>Tranformed image.</returns>
        public IImage Transform(Action<ITransformation> transformFunction)
        {
            var transformation = new Transformation(image);
            transformFunction(transformation);

            return new Image(transformation.Execute());
        }
    }
}
