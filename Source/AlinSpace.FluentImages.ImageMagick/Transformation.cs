using ImageMagick;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlinSpace.FluentImages.Magick
{
    /// <summary>
    /// Transformation implementation for <see cref="ITransformation"/>.
    /// </summary>
    public class Transformation : ITransformation
    {
        IMagickImage<ushort> image;
        IMagickImage<ushort> newImage;

        DrawableAffine affineMatrix = new DrawableAffine();
        MatrixFactory f;
        public int Width => image.Width;

        public int Height => image.Height;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        public Transformation(IMagickImage<ushort> image)
        {
            this.image = image;
            newImage = image.Clone();
        }

        public void Scale(double x, double y)
        {
            affineMatrix.TransformScale(x, y);
        }

        public void Translate(int x, int y)
        {
           
        }

        public void Rotate(double degrees)
        {
            affineMatrix.TransformRotation(degrees);
        }

        /// <summary>
        /// Execute transformation.
        /// </summary>
        /// <returns>Transformed bitmap.</returns>
        public IMagickImage<ushort> Execute()
        {
            newImage.AffineTransform(affineMatrix);
            return newImage;
        }

        public void Dispose()
        {
        }
    }
}
