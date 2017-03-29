using System;
using System.Collections.Generic;
using System.Numerics;

namespace Antennas
{
    /// <summary>
    /// Класс объектов, занимающихся изменениями функции ДН
    /// </summary>
    public class PtternManager
    {
        /// <summary>
        /// Один одсчёт диаграммы направленности
        /// </summary>
        public struct BeamValue
        {
            /// <summary>
            /// Угол измеренного значения ДН
            /// </summary>
            public double th;
            /// <summary>
            /// Измерянное значение ДН для указанного угла
            /// </summary>
            public Complex value;

            public double Abs { get { return Math.Sqrt(Power); } }
            public double Phase { get { return Math.Atan2(value.Imaginary, value.Real); } }
            public double Power { get { return value.Real * value.Real + value.Imaginary * value.Imaginary; } }
            public double Power_db { get { return Math.Log10(Power); } }
        }

        /// <summary>
        /// Массив измерянных значений ДН
        /// </summary>
        public BeamValue[] Values { get; }

        /// <summary>
        /// Инициализация нового менеджера ДН антенны
        /// </summary>
        /// <param name="pattern">Функция ДН антенны</param>
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