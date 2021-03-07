using System;
using System.Drawing.Imaging;

namespace AlinSpace.FluentImages.Gdi
{
    /// <summary>
    /// Extensions for <see cref="Format"/>.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Convert to SkiaSharp image format.
        /// </summary>
        /// <param name="format">Format to convert.</param>
        /// <returns>Converted format.</returns>
        public static ImageFormat ToGdiFormat(this Format format)
        {
            return format switch
            {
                Format.Png => ImageFormat.Png,
                Format.Jpeg => ImageFormat.Jpeg,
                _ => throw new Exception($"Format not supported: {format}"),
            };
        }
    }
}
