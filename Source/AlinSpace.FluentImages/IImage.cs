using System;
using System.IO;

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
        /// Clone the image.
        /// </summary>
        /// <returns>Cloned image.</returns>
        IImage Clone();

        /// <summary>
        /// Export image to stream.
        /// </summary>
        /// <param name="stream">Stream to export the image to..</param>
        /// <param name="format">Format for the encoding.</param>
        /// <param name="quality">Quality hint.</param>
        /// <returns>Byte array.</returns>
        void ExportToStream(Stream stream, Format format, Quality quality);

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        IImage ResizeTo(int width, int height);

        /// <summary>
        /// Map image to rectangle area.
        /// </summary>
        /// <param name="rectangle">Rectangle.</param>
        /// <returns>Mapped image.</returns>
        IImage MapTo(Rectangle rectangle);

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

        /// <summary>
        /// Apply blend layer.
        /// </summary>
        /// <param name="layer">Image blend layer.</param>
        /// <param name="mode">Blending mode to use when applying the blend layer.</param>
        /// <returns></returns>
        //IImage BlendWithLayer(IImage layer, BlendMode mode = BlendMode.Normal);
    }
}
