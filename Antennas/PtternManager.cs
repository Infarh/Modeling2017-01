using System;
using System.Collections.Generic;
using System.Numerics;

namespace Antennas
{
    /// <summary>
    /// ����� ��������, ������������ ����������� ������� ��
    /// </summary>
    public class PtternManager
    {
        /// <summary>
        /// ���� ������ ��������� ��������������
        /// </summary>
        public struct BeamValue
        {
            /// <summary>
            /// ���� ����������� �������� ��
            /// </summary>
            public double th;
            /// <summary>
            /// ���������� �������� �� ��� ���������� ����
            /// </summary>
            public Complex value;

            public double Abs { get { return Math.Sqrt(Power); } }
            public double Phase { get { return Math.Atan2(value.Imaginary, value.Real); } }
            public double Power { get { return value.Real * value.Real + value.Imaginary * value.Imaginary; } }
            public double Power_db { get { return Math.Log10(Power); } }
        }

        /// <summary>
        /// ������ ���������� �������� ��
        /// </summary>
        public BeamValue[] Values { get; }

        /// <summary>
        /// ������������� ������ ��������� �� �������
        /// </summary>
        /// <param name="pattern">������� �� �������</param>
        public PtternManager(Func<double, Complex> pattern)
        {
            const double to_rad = Math.PI / 180;
            var dth = 0.5 * to_rad;
            var th1 = -90 * to_rad;
            var th2 = 90 * to_rad;

            var list = new List<BeamValue>();

            while(th1 < th2)
            {
                var v = new BeamValue();
                v.th = th1;
                v.value = pattern(th1);
                list.Add(v);
                th1 += dth;
            }
            Values = list.ToArray();
        }

    }
}