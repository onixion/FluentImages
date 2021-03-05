using System;
using System.Collections.Generic;
using System.Text;

namespace AlinSpace.FluentImages
{
    public static class Degrees
    {
        public static double ToPositive(this double degrees)
        {
            var p = degrees / 360.0;

            if (degrees < 0)
            {
                return 360.0 - p;
            }

            return p;
        }
    }
}
