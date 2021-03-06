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
        /// <returns>Byte array.</returns>
        void ExportToStream(Stream stream, Format format);

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        IImage ResizeTo(int width, int height);

        /// <summary>
        /// Transform image.
        /// </summary>
        /// <param name="transformFunction">Transform function.</param>
        /// <returns>Tranformed image.</returns>
        IImage Transform(Action<IImageTransform> transformFunction);

        /// <summary>
        /// Apply blend layer.
        /// </summary>
        /// <param name="layer">Image blend layer.</param>
        /// <param name="mode">Blending mode to use when applying the blend layer.</param>
        /// <returns></returns>
        //IImage BlendWithLayer(IImage layer, BlendMode mode = BlendMode.Normal);
    }
}
