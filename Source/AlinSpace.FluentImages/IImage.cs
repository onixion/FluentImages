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
    }
}
