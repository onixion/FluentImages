using System;
using System.Drawing;

namespace AlinSpace.FluentImages.Gdi
{
    public static class FlipDirectionExtensions
    {
        public static RotateFlipType ToRotateFlipType(this FlipDirection direction)
        {
            switch(direction)
            {
                case FlipDirection.Both:
                    return RotateFlipType.RotateNoneFlipXY;

                case FlipDirection.Horizontal:
                    return RotateFlipType.RotateNoneFlipX;

                case FlipDirection.Vertical:
                    return RotateFlipType.RotateNoneFlipY;

                default:
                    throw new Exception($"Unsupported flip direction: {direction}");
            }
        }

        public static Rectangle ToRectangle(this FlipDirection direction, int width, int height)
        {
            switch (direction)
            {
                case FlipDirection.Horizontal:
                    return new Rectangle(
                        left: 0,
                        top: height,
                        right: width,
                        bottom: 0);

                case FlipDirection.Vertical:
                    return new Rectangle(
                        left: width,
                        top: 0,
                        right: 0,
                        bottom: height);

                case FlipDirection.Both:
                    return new Rectangle(
                        left: width,
                        top: height,
                        right: 0,
                        bottom: 0);

                default:
                    throw new Exception($"Unsupported flip direction: {direction}");
            }
        }
    }
}
