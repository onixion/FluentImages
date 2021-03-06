using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="Format"/>.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Is format compatible with the given image file extension.
        /// </summary>
        /// <param name="format">Format.</param>
        /// <param name="extension">File extension.</param>
        /// <returns>True, if compatible; false otherwise.</returns>
        public static bool CompatibleWithFileExtension(this Format format, string extension)
        {
            switch (format)
            {
                case Format.Png:
                    if (extension.ToLower() == "png")
                        return true;
                    break;

                case Format.Jpeg:
                    if (extension.ToLower() == "jpg")
                        return true;
                    if (extension.ToLower() == "jpeg")
                        return true;
                    break;
            }

            return false;
        }

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
                Format.Jpeg => "jpg",
                _ => throw new Exception($"Format not supported: {format}"),
            };
        }
    }
}
