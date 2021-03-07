using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Extensions for <see cref="ITransformation"/>.
    /// </summary>
    public static class TransformationExtensions
    {
        /// <summary>
        /// Flip.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="direction">Flip direction.</param>
        /// <returns>Transform.</returns>
        public static ITransformation Flip(this ITransformation transform, FlipDirection direction)
        {
            switch (direction)
            {
                case FlipDirection.Both:
                    transform.Translate(transform.Width, transform.Height);
                    transform.Scale(-1.0, -1.0);
                    break;

                case FlipDirection.Horizontal:
                    transform.Translate(0, transform.Height);
                    transform.Scale(1.0, -1.0);
                    break;

                case FlipDirection.Vertical:
                    transform.Translate(transform.Width, 0);
                    transform.Scale(-1.0, 1.0);
                    break;

                default:
                    throw new Exception($"Unsupported flip direction: {direction}");
            }

            return transform;
        }

        /// <summary>
        /// Map to.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="rectangle">Area to map to.</param>
        /// <returns>Transform.</returns>
        public static ITransformation MapTo(this ITransformation transform, Rectangle rectangle)
        {
            transform.Scale(
                x: (double)rectangle.Width / transform.Width,
                y: (double)rectangle.Heigth / transform.Width);

            transform.Translate(
                x: rectangle.Left, 
                y: rectangle.Top);

            return transform;
        }

        #region Rotate

        /// <summary>
        /// Rotate in degrees.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Transform.</returns>
        public static ITransformation RotateInDegrees(this ITransformation transform, double degrees, int x, int y)
        {
            transform.Translate(x, y);
            transform.Rotate(degrees);
            transform.Translate(-x, -y);

            return transform;
        }

        /// <summary>
        /// Rotate in degress around center point.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="degrees">Degrees to rotate.</param>
        /// <returns>Transform.</returns>
        public static ITransformation RotateInDegrees(this ITransformation transform, double degrees)
        {
            return transform.RotateInDegrees(
                degrees: degrees,
                x: (int)(transform.Width / 2.0),
                y: (int)(transform.Height / 2.0));
        }

        /// <summary>
        /// Rotate in percentage.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="percentage">Percentage to rotate.</param>
        /// <param name="x">X coordinate of the rotation point.</param>
        /// <param name="y">Y coordinate of the rotation point.</param>
        /// <returns>Transform.</returns>
        public static ITransformation RotateInPercentage(this ITransformation transform, double percentage, int x, int y)
        {
            return transform.RotateInDegrees(percentage * 360.0f, x, y);
        }

        /// <summary>
        /// Rotate in percentage around center point.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="percentage">Percentage to rotate.</param>
        /// <returns>Transform.</returns>
        public static ITransformation RotateInPercentage(this ITransformation transform, double percentage)
        {
            return transform.RotateInDegrees(percentage * 360.0f);
        }

        #endregion
    }
}
