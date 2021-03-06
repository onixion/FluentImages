using SkiaSharp;

namespace AlinSpace.FluentImages.SkiaSharp
{
    public class ImageTransform : IImageTransform
    {
        SKBitmap bitmap;
        SKBitmap newBitmap;

        SKCanvas canvas;

        public int Width => bitmap.Width;

        public int Height => bitmap.Height;

        public ImageTransform(SKBitmap bitmap)
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
            canvas.Translate((float)x, (float)y);
        }

        public void Rotate(double degrees)
        {
            canvas.RotateDegrees((float)degrees);
        }

        public SKBitmap Transform()
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
