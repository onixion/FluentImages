using ImageMagick;
using System;

namespace AlinSpace.FluentImages.Magick
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
        public static MagickFormat ToMagickFormat(this Format format)
        {
            return format switch
            {
                Format.Png => MagickFormat.Png,
                Format.Jpg => MagickFormat.Jpeg,
                _ => throw new Exception($"Format not supported: {format}"),
            };
        }
    }
}
