using System;
using System.Numerics;

namespace Antennas
{
    public abstract class Antenna
    {
        public double D { get { return GetKND(); } }

        private double GetKND()
        {
            Func<double, double> g = th => Pattern(th).Sqr() * Math.Cos(th);
            var I = g.Integrate_Adaptive(-Math.PI / 2, Math.PI / 2);
            return 2 / I;
        }

        public abstract Complex Pattern(double th);
    }
}