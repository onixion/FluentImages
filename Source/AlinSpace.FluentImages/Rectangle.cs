using System;

namespace AlinSpace.FluentImages
{
    public struct Rectangle
    {
        public int Left { get; }

        public int Top { get; }

        public int Right { get; }

        public int Bottom { get; }

        public int Width => Right - Left;

        public int Heigth => Bottom - Top;

        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
