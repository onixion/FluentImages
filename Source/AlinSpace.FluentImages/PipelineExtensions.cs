namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="Pipeline"/>.
    /// </summary>
    public static class PipelineExtensions
    {
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
            pipeline.AddStage(image 
                => image.ResizeTo(
                    (int)(image.Width * widthNormalized), 
                    (int)(image.Height * heigthNormalized)));

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
    }
}
