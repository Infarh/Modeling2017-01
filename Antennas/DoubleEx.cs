using System;

namespace Antennas
{
    public static class DoubleEx
    {
        public static double In_db(this double x)
        {
            return 20 * Math.Log10(x);
        }

        public static double In_db_P(this double x)
        {
            return 10 * Math.Log10(x);
        }
    }
}
