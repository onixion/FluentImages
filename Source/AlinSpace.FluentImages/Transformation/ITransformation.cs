using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Transformation interface.
    /// </summary>
    public interface ITransformation : IDisposable
    {
        /// <summary>
        /// Width of the image.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of the image.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Scale.
        /// </summary>
        /// <param name="x">X factor.</param>
        /// <param name="y">Y factor.</param>
        void Scale(double x, double y);

        /// <summary>
        /// Translate.
        /// </summary>
        /// <param name="x">X delta.</param>
        /// <param name="y">Y delta.</param>
        void Translate(int x, int y);

        /// <summary>
        /// Rotate.
        /// </summary>
        /// <param name="degrees">Degrees.</param>
        void Rotate(double degrees);
    }
}
