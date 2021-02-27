using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="Format"/>.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Convert format to file extension.
        /// </summary>
        /// <param name="format">Format to convert.</param>
        /// <returns>Converted format.</returns>
        public static string ToFileExtension(this Format format)
        {
            return format switch
            {
                Format.Png => "png",
                Format.Jpg => "jpg",
                _ => throw new Exception($"Format not supported: {format}"),
            };
        }
    }
}
