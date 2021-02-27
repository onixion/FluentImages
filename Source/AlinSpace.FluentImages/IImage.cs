using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Image interface.
    /// </summary>
    public interface IImage : IDisposable
    {
        /// <summary>
        /// Width of image.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of image.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Import image from raw byte array.
        /// </summary>
        /// <param name="rawBytes">Image as raw byte array.</param>
        void Import(byte[] rawBytes);

        /// <summary>
        /// Export image to raw byte array.
        /// </summary>
        /// <param name="format">Format to encode the image to.</param>
        /// <param name="quality">Quality.</param>
        /// <returns>Byte array.</returns>
        byte[] Export(Format format, Quality quality = Quality.Best);

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        IImage ResizeTo(int width, int height);

        /// <summary>
        /// Flip image.
        /// </summary>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Flipped image.</returns>
        IImage Flip(FlipDirection direction);

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Rotated image.</returns>
        IImage RotateInDegrees(double degrees, double x, double y);
    }
}
