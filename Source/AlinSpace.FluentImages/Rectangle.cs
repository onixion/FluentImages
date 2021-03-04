namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Rectangle.
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// Left number of pixels.
        /// </summary>
        public int Left { get; }

        /// <summary>
        /// Top number of pixels.
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// Right number of pixels.
        /// </summary>
        public int Right { get; }

        /// <summary>
        /// Bottom number of pixels.
        /// </summary>
        public int Bottom { get; }

        /// <summary>
        /// Width in pixels.
        /// </summary>
        public int Width => Right - Left;

        /// <summary>
        /// Height in pixels.
        /// </summary>
        public int Heigth => Bottom - Top;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Rectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
