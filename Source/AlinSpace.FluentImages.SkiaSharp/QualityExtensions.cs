using System;
using System.Collections.Generic;
using System.Text;

namespace AlinSpace.FluentImages.SkiaSharp
{
    /// <summary>
    /// Extensions for <see cref="Quality"/>.
    /// </summary>
    public static class QualityExtensions
    {
        /// <summary>
        /// Convert to SkiaSharp quality.
        /// </summary>
        /// <param name="quality">Quality to convert.</param>
        /// <returns>Converted quality.</returns>
        public static int ToSkiaQuality(this Quality quality)
        {
            return 100;
        }
    }
}
