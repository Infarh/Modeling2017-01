using System;
using System.Numerics;

namespace Antennas
{
    /// <summary>Симметричный вибратор</summary>
    public class Vibrator : Antenna
    {
        /// <summary>Длина вибратора, нормированная к длине волны</summary>
        private readonly double f_Length;

        /// <summary>Длина вибратора, нормированная к длине волны</summary>
        public double Length { get { return f_Length; } }

        public Vibrator(double Length)
        {
            f_Length = Length;
        }

        public override Complex Pattern(double th)
        {
            var pi_l = 2 * Math.PI * f_Length;
            var f = (Math.Cos(pi_l * Math.Sin(th)) - Math.Cos(pi_l)) / ((1 - Math.Cos(pi_l)) * Math.Cos(th));
            return f;
        }
    }
}