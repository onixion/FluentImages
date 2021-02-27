using System.IO;
using System.Linq;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="IImage"/>.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Get aspect ratio of the image.
        /// </summary>
        /// <param name="image">Image.</param>
        /// <returns>Aspect ratio.</returns>
        public static double GetAspectRatio(this IImage image)
        {
            return (double)image.Width / image.Height;
        }

        /// <summary>
        /// Export image to file.
        /// </summary>
        /// <param name="image">Image to export.</param>
        /// <param name="path">Path to the file.</param>
        /// <param name="format">Image format for encoding.</param>
        /// <param name="quality">Image quality to use.</param>
        /// <remarks>
        /// If the path does not contain a valid image file extension, the file extension will be added.
        /// </remarks>
        public static void ExportToFile(this IImage image, string path, Format format = Format.Jpg, Quality quality = Quality.Best)
        {
            var rawBytes = image.Export(format, quality);

            if (!Path.HasExtension(path))
            {
                path = $"{path}.{format.ToFileExtension()}";
            }
            else
            {
                var extension = Path.GetExtension(path).Skip(1).ToArray().ToString();

                if (!format.CompatibleWithFileExtension(extension))
                {
                    path = $"{path}.{format.ToFileExtension()}";
                }
            }

            File.WriteAllBytes(path, rawBytes);
        }

        /// <summary>
        /// Export image to file.
        /// </summary>
        /// <param name="image">Image to export.</param>
        /// <param name="stream">Stream to export to.</param>
        /// <param name="format">Image format for encoding.</param>
        /// <param name="quality">Image quality to use.</param>
        public static void ExportToStream(this IImage image, Stream stream, Format format = Format.Jpg, Quality quality = Quality.Best)
        {
            var rawBytes = image.Export(format, quality);
            stream.Write(rawBytes, 0, rawBytes.Length);
        }
    }
}
