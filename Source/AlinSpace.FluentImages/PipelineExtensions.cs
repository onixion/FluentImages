namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="Pipeline"/>.
    /// </summary>
    public static class PipelineExtensions
    {
        #region Export

        /// <summary>
        /// Execute pipeline.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="image">Image to push through the pipeline.</param>
        /// <param name="path">Path to export the file to.</param>
        /// <param name="format">Format to export to.</param>
        /// <param name="quality">Quality when exporting.</param>
        /// <returns>New image created by the pipeline.</returns>
        public static Pipeline ExecuteAndExportToFile(this Pipeline pipeline, IImage image, string path, Format format = Format.Jpg, Quality quality = Quality.Best)
        {
            var outputImage = pipeline.Execute(image);
            outputImage.ExportToFile(path, format, quality);

            return pipeline;
        }

        #endregion

        #region Resizing

        /// <summary>
        /// Resize image to a specific size.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <returns>New resized image.</returns>
        public static Pipeline ResizeTo(this Pipeline pipeline, int width, int height)
        {
            pipeline.AddStage(image => image.ResizeTo(width, height));
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
            pipeline.AddStage(image => 
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
            return pipeline.AddStage(image =>
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
            return pipeline.AddStage(image =>
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
            return pipeline.AddStage(image =>
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
            return pipeline.AddStage(image =>
            {
                var newHeight = (image.Height * heightFactor);
                var newWidth = newHeight * image.GetAspectRatio();

                return image.ResizeTo((int)newWidth, (int)newHeight);
            });
        }

        #endregion

        #region Flipping

        /// <summary>
        /// Flip image.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline Flip(this Pipeline pipeline, FlipDirection direction)
        {
            return pipeline.AddStage(image => image.Flip(direction));
        }

        #endregion

        #region Rotating

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInDegrees(this Pipeline pipeline, double degrees, double x, double y)
        {
            return pipeline.AddStage(image => image.RotateInDegrees(degrees, x, y));
        }

        /// <summary>
        /// Rotate image in degrees.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInDegrees(this Pipeline pipeline, double degrees)
        {
            return pipeline.AddStage(image => 
                image.RotateInDegrees(
                    degrees: degrees, 
                    x: image.Width / 2.0f,
                    y: image.Height / 2.0f));
        }

        /// <summary>
        /// Rotate image in percentage.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="factor">Normalized percentage value.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInPercentage(this Pipeline pipeline, double factor, double x, double y)
        {
            return pipeline.AddStage(image => 
                image.RotateInDegrees(
                    degrees: factor * 360.0, 
                    x: x, 
                    y: y));
        }

        /// <summary>
        /// Rotate image in percentage.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <param name="factor">Normalized percentage value.</param>
        /// <returns>Pipeline.</returns>
        public static Pipeline RotateInPercentage(this Pipeline pipeline, double factor)
        {
            return pipeline.AddStage(image =>
                image.RotateInDegrees(
                    degrees: factor * 360.0,
                    x: image.Width / 2.0f,
                    y: image.Height / 2.0f));
        }

        #endregion
    }
}
