using SkiaSharp;
using System;
using System.IO;

namespace AlinSpace.FluentImages.SkiaSharp
{
    /// <summary>
    /// Image implementation for <see cref="SKBitmap"/>.
    /// </summary>
    public class Image : IImage
    {
        readonly SKBitmap bitmap;

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
            bitmap = SKBitmap.Decode(stream);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rawImageData">Raw image data.</param>
        public Image(byte[] rawImageData)
        {
            bitmap = SKBitmap.Decode(rawImageData);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image">Image.</param>
        public Image(Image image)
        {
            bitmap = image.bitmap.Copy();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        private Image(SKBitmap bitmap)
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
            bitmap.Encode(stream, format.ToSkiaFormat(), 100);
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

        /// <summary>
        /// Transform image.
        /// </summary>
        /// <param name="transformationFunction">Transformation function.</param>
        /// <returns>Tranformed image.</returns>
        public IImage Transform(Action<ITransformation> transformationFunction)
        {
            using Transformation imageTransform = new Transformation(bitmap);
            transformationFunction(imageTransform);

            return new Image(imageTransform.Execute());
        }
    }
}
