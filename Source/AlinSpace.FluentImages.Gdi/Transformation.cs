using System.Drawing;

namespace AlinSpace.FluentImages.Gdi
{
    /// <summary>
    /// Transformation implementation for <see cref="System.Drawing.Image"/>
    /// </summary>
    public class Transformation : ITransformation
    {
        System.Drawing.Image image;
        System.Drawing.Bitmap newImage;
        Graphics graphics;

        /// <summary>
        /// Width of the image.
        /// </summary>
        public int Width => image.Width;

        /// <summary>
        /// Height of the image.
        /// </summary>
        public int Height => image.Height;

        public Transformation(System.Drawing.Image image)
        {
            this.image = image;
            newImage = new Bitmap(image.Width, image.Height);
            newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            graphics = Graphics.FromImage(newImage);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            graphics.Dispose();
        }

        public System.Drawing.Image Execute()
        {
            graphics.DrawImage(image, Point.Empty);
            return newImage;
        }

        public void Rotate(double degrees)
        {
            graphics.RotateTransform((float)degrees);
        }

        public void Scale(double x, double y)
        {
            graphics.ScaleTransform((float)x, (float)y);
        }

        public void Translate(int x, int y)
        {
            graphics.TranslateTransform(x, y);
        }
    }
}
