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
    }
}
