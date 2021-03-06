namespace AlinSpace.FluentImages
{
    public static class RectangleExtensions
    {
        public static Rectangle MoveBy(this Rectangle rectangle, int dx, int dy)
        {
            return new Rectangle(
                left: rectangle.Left + dx,
                top: rectangle.Top + dy,
                right: rectangle.Left + rectangle.Width + dx,
                bottom: rectangle.Bottom + rectangle.Heigth + dy);
        }

        public static Rectangle MoveTo(this Rectangle rectangle, int x, int y)
        {
            return new Rectangle(
                left: x,
                top: y,
                right: rectangle.Width + x,
                bottom: rectangle.Heigth + y);
        }
    }
}
