using System;
using System.IO;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="Pipeline"/>.
    /// </summary>
    public static class PipelineExtensions
    {
        #region Export

        /// <summary>
        /// Execute pipeline and export image to stream.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="image">Image to push through the pipeline.</param>
        /// <param name="stream">Stream to export to.</param>
        /// <param name="format">Format to export to.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ExecuteExportToFile(this Pipeline pipeline, IImage image, Stream stream, Format format = Format.Jpeg)
        {
            var outputImage = pipeline.Execute(image);
            outputImage.ExportToStream(stream, format);
            return pipeline;
        }

        /// <summary>
        /// Execute pipeline and export image to file.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="image">Image to push through the pipeline.</param>
        /// <param name="path">Path to export the file to.</param>
        /// <param name="format">Format to export to.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ExecuteExportToFile(this Pipeline pipeline, IImage image, string path, Format format = Format.Jpeg)
        {
            var outputImage = pipeline.Execute(image);
            outputImage.ExportToFile(path, format);
            return pipeline;
        }

        #endregion

        #region Resize

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public static Pipeline ResizeTo(this Pipeline pipeline, int width, int height)
        {
            pipeline.AddFunction(image => image.ResizeTo(width, height));
            return pipeline;
        }

        /// <summary>
        /// Resize image with normalized percentage values.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="widthNormalized">Width.</param>
        /// <param name="heigthNormalized">Height.</param>
        /// <returns>New resized image.</returns>
        public static Pipeline ResizeInPercentage(this Pipeline pipeline, double widthNormalized, double heigthNormalized)
        {
            pipeline.AddFunction(image =>
                image.ResizeTo(
                    width: (int)(image.Width * widthNormalized),
                    height: (int)(image.Height * heigthNormalized)));

            return pipeline;
        }

        /// <summary>
        /// Resize image to a specific width and keep the aspect ratio the same.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="width">Width of new image.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ResizeToWidth(this Pipeline pipeline, int width)
        {
            return pipeline.AddFunction(image =>
            {
                var newHeight = (int)(width / image.GetAspectRatio());
                return image.ResizeTo(width, newHeight);
            });
        }

        /// <summary>
        /// Resize image to a specific height and keep the aspect ratio the same.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="height">Height of new image.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ResizeToHeight(this Pipeline pipeline, int height)
        {
            return pipeline.AddFunction(image =>
            {
                var newWidth = (int)(image.GetAspectRatio() * height);
                return image.ResizeTo(newWidth, height);
            });
        }

        /// <summary>
        /// Resize image to a specific scaled width and keep the aspect ratio the same.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="widthFactor">Width factor.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ResizeToWidthScaled(this Pipeline pipeline, double widthFactor)
        {
            return pipeline.AddFunction(image =>
            {
                var newWidth = (image.Width * widthFactor);
                var newHeight = newWidth / image.GetAspectRatio();

                return image.ResizeTo((int)newWidth, (int)newHeight);
            });
        }

        /// <summary>
        /// Resize image to a specific scaled height and keep the aspect ratio the same.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="heightFactor">Height factor.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline ResizeToHeightScaled(this Pipeline pipeline, double heightFactor)
        {
            return pipeline.AddFunction(image =>
            {
                var newHeight = (image.Height * heightFactor);
                var newWidth = newHeight * image.GetAspectRatio();

                return image.ResizeTo((int)newWidth, (int)newHeight);
            });
        }

        #endregion

        #region Transform

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="transformFunction">Transform function.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline Transform(this Pipeline pipeline, Action<IImageTransform> transformFunction)
        {
            return pipeline.AddFunction(image => image.Transform(transformFunction));
        }

        #region MapTo

        /// <summary>
        /// Map image to rectangle area.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="rectangle">Area to map to.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline MapTo(this Pipeline pipeline, Rectangle rectangle)
        {
            return pipeline.AddFunction(
                image => image.Transform(
                    transform => transform.MapTo(rectangle)));
        }

        #endregion

        #region Flip

        /// <summary>
        /// Flip image.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline Flip(this Pipeline pipeline, FlipDirection direction)
        {
            return pipeline.AddFunction(
                image => image.Transform(
                    transform => transform.Flip(direction)));
        }

        #endregion

        #region Rotate

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInDegrees(this Pipeline pipeline, double degrees, int x, int y)
        {
            return pipeline.AddFunction(image => image.Transform(transform => transform.RotateInDegrees(degrees, x, y)));
        }

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInDegrees(this Pipeline pipeline, double degrees)
        {
            return pipeline.AddFunction(image => image.Transform(transform => transform.RotateInDegrees(degrees)));
        }

        /// <summary>
        /// Rotate image in percentage.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="percentage">Percentage to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInPercentage(this Pipeline pipeline, double percentage, int x, int y)
        {
            return pipeline.Transform(t => t.RotateInPercentage(percentage, x, y));
        }

        /// <summary>
        /// Rotate image in percentage.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="percentage">Percentage to rotate.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInPercentage(this Pipeline pipeline, double percentage)
        {
            return pipeline.Transform(t => t.RotateInPercentage(percentage));
        }

        #endregion

        #endregion
    }
}
