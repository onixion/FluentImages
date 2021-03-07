using SkiaSharp;

namespace AlinSpace.FluentImages.SkiaSharp
{
    /// <summary>
    /// Transformation implementation of <see cref="ITransformation"/>.
    /// </summary>
    public class Transformation : ITransformation
    {
        readonly SKBitmap bitmap;
        readonly SKBitmap newBitmap;
        readonly SKCanvas canvas;

        public int Width => bitmap.Width;

        public int Height => bitmap.Height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        public Transformation(SKBitmap bitmap)
        {
            this.bitmap = bitmap;
            newBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            canvas = new SKCanvas(newBitmap);
        }

        public void Scale(double x, double y)
        {
            canvas.Scale((float)x, (float)y);
        }

        public void Translate(int x, int y)
        {
            canvas.Translate(x, y);
        }

        public void Rotate(double degrees)
        {
            canvas.RotateDegrees((float)degrees);
        }

        /// <summary>
        /// Execute transformation.
        /// </summary>
        /// <returns>Transformed bitmap.</returns>
        public SKBitmap Execute()
        {
            canvas.DrawBitmap(bitmap, 0.0f, 0.0f);
            return newBitmap;
        }

        public void Dispose()
        {
            canvas.Dispose();
        }
    }
}
