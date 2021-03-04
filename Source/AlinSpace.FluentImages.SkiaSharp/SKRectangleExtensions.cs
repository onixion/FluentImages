using SkiaSharp;

namespace AlinSpace.FluentImages.SkiaSharp
{
    public static class SKRectangleExtensions
    {
        public static SKRect ToSKRectangle(this Rectangle rectangle)
        {
            return new SKRect(
                left: rectangle.Left,
                top: rectangle.Top,
                right: rectangle.Right,
                bottom: rectangle.Bottom);
        }
    }
}
