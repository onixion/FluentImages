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
            // If path has no extension.
            if (!Path.HasExtension(path))
            {
                path = $"{path}.{format.ToFileExtension()}";
            }
            // Path has extension.
            else
            {
                // Get extension.
                var extension = new string(Path.GetExtension(path).Skip(1).ToArray());

                // Check if the format and the extension are compatible.
                if (!format.CompatibleWithFileExtension(extension))
                {
                    // If not add the extension for the given format
                    // at the end of the path.
                    path = $"{path}.{format.ToFileExtension()}";
                }
            }

            // Open file stream.
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);

            // Export image to stream.
            image.ExportToStream(fileStream, format, quality);
        }

        /// <summary>
        /// Export image to raw byte array.
        /// </summary>
        /// <param name="image">Image to export.</param>
        /// <param name="format">Image format for encoding.</param>
        /// <param name="quality">Image quality to use.</param>
        /// <returns>Raw byte array data.</returns>
        public static byte[] ExportToByteArray(this IImage image, Format format = Format.Jpg, Quality quality = Quality.Best)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.ExportToStream(memoryStream, format, quality);
                return memoryStream.ToArray();
            }
        }
    }
}
