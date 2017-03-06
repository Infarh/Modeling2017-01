using System.Numerics;

namespace Antennas
{
    internal static class ComplexEx
    {
        public static Complex ComplexConjugate(this Complex z)
        {
            return new Complex(z.Real, -z.Imaginary);
        }

        public static double Sqr(this Complex z)
        {
            return (z * z.ComplexConjugate()).Magnitude;
        }
    }
}