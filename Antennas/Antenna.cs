using System;
using System.Numerics;

namespace Antennas
{
    public abstract class Antenna
    {
        /// <summary>
        /// ��� �������
        /// </summary>
        public double D { get { return GetKND(); } }

        /// <summary>
        /// �������� ��������� �������������� �������
        /// </summary>
        public PtternManager BeamManager { get { return new PtternManager(Pattern); } }

        private double GetKND()
        {
            Func<double, double> g = th => Pattern(th).Sqr() * Math.Cos(th);
            var I = g.Integrate_Adaptive(-Math.PI / 2, Math.PI / 2);
            return 2 / I;
        }

        public abstract Complex Pattern(double th);
    }
}