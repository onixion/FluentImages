namespace AlinSpace.FluentImages.Gdi
{
    public static class RectangleExtensions
    {
        public static System.Drawing.Rectangle ToRectangle(this Rectangle rectangle)
        {
            return new System.Drawing.Rectangle(
                x: rectangle.Left,
                y: rectangle.Top,
                width: rectangle.Width,
                height: rectangle.Heigth);
        }
    }
}
