using SkiaSharp;
using System;

namespace AlinSpace.FluentImages.SkiaSharp
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
        public static SKEncodedImageFormat ToSkiaFormat(this Format format)
        {
            return format switch
            {
                Format.Png => SKEncodedImageFormat.Png,
                Format.Jpeg => SKEncodedImageFormat.Jpeg,
                _ => throw new Exception($"Format not supported: {format}"),
            };
        }
    }
}
