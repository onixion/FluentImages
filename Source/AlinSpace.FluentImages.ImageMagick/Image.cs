using ImageMagick;
using System;
using System.IO;

namespace AlinSpace.FluentImages.Magick
{
    /// <summary>
    /// Image implementation for <see cref="IMagickImage{ushort}"/>.
    /// </summary>
    public class Image : IImage
    {
        readonly IMagickImage<ushort> image;

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
            image = new MagickImage(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rawBytes">Image as raw bytes.</param>
        public Image(byte[] rawBytes)
        {
            image = new MagickImage(rawBytes);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image">Image.</param>
        public Image(Image image)
        {
            this.image = image.image.Clone();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image">Image.</param>
        private Image(IMagickImage<ushort> image)
        {
            this.image = image.Clone();
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
            var data = image.ToByteArray(format.ToMagickFormat());
            stream.Write(data);
        }

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public IImage ResizeTo(int width, int height)
        {
            image.Resize(width, height);
            return this;
        }

        /// <summary>
        /// Transform image.
        /// </summary>
        /// <param name="transformFunction">Transform function.</param>
        /// <returns>Tranformed image.</returns>
        public IImage Transform(Action<ITransformation> transformFunction)
        {

        }
    }
}
