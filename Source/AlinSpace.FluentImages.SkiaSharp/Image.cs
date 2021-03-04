﻿using SkiaSharp;
using System;
using System.IO;

namespace AlinSpace.FluentImages.SkiaSharp
{
    /// <summary>
    /// Image implementation for SkiaSharp.
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
        /// <param name="quality">Quality hint.</param>
        /// <returns>Byte array.</returns>
        public void ExportToStream(Stream stream, Format format, Quality quality)
        {
            

            //bitmap.Encode()

            bitmap.Encode(stream, format.ToSkiaFormat(), quality.ToSkiaQuality());
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
        /// Flip image.
        /// </summary>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Flipped image.</returns>
        public IImage Flip(FlipDirection direction)
        {
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

            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                canvas.Scale(sx, sy, px, py);
                canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
            }

            return this;
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
            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                canvas.RotateDegrees((float)degrees, (float)x, (float)y);
                canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
            }

            return this;
        }

        /// <summary>
        /// Translate image by pixel offset.
        /// </summary>
        /// <param name="x">X coordinate pixel offset.</param>
        /// <param name="y">Y coordinate pixel offset.</param>
        /// <returns></returns>
        public IImage TranslateBy(int x, int y)
        {
            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                canvas.Translate(x, y);
                canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
            }

            return this;
        }
    }
}
