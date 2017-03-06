using System;

namespace Antennas
{
    internal static class FunctionsService
    {
        /// <summary>Вычисление модуля вещественного числа</summary>
        /// <param name="x">Целое число</param>
        /// <returns>Модуль целого числа</returns>
        private static double Abs(this double x) => Math.Abs(x);
        /// <summary>Вычисление модуля вещественного числа</summary>
        /// <param name="x">Вещественное число</param>
        /// <returns>Модуль вещественного числа</returns>
        private static int Abs(this int x) => Math.Abs(x);

        public static double Integrate(this Func<double, double> f, double a, double b, double dx = 0)
        {
            if(a.Equals(b)) return 0;
            if(dx <= 0) dx = Math.Abs(b - a) / 100;

            var s = f(a) / 2;
            b -= dx;
            while((a += dx) < b) s += f(a);
            var f05 = f(a) / 2;
            s += f05;
            s *= dx;
            s += (f05 + f(b += dx)) * (b - a);
            return s;
        }

        public static double Integrate_Simpson_dx(this Func<double, double> f, double a, double b, double dx, double s0 = 0)
        {
            if(a.Equals(b)) return 0;
            var dx05 = dx / 2;
            var x = a;
            var s1 = .0;
            var s2 = f(x + dx05);

            var N = (int)((b - a) / dx).Abs();
            for(var i = 1; i < N; i++)
            {
                s1 += f(x += dx);
                s2 += f(x + dx05);
            }
            return dx / 6 * (f(a) + 2 * s1 + 4 * s2 + f(b));
        }

        public static double Integrate_Simpson(this Func<double, double> f, double a, double b, int N = 100, double s0 = 0)
        {
            if(a.Equals(b)) return 0;

            var dx = (b - a).Abs() / N;

            var dx05 = dx / 2;
            var x = a;
            var s1 = .0;
            var s2 = f(x + dx05);

            for(var i = 1; i < N; i++)
            {
                s1 += f(x += dx);
                s2 += f(x + dx05);
            }
            return dx / 6 * (f(a) + 2 * s1 + 4 * s2 + f(b));
        }

        public static double Integrate_Adaptive(this Func<double, double> f, double a, double b, int N = 2, double e = 1e-6)
        {
            if(a.Equals(b)) return 0;

            var I1 = f.Integrate_Simpson(a, b, N);
            var I2 = f.Integrate_Simpson(a, b, N * 2);
            if((I1 - I2).Abs() < e) return I2;
            var ab05 = (a + b) / 2;
            return f.Integrate_Adaptive(a, ab05, N, e) + f.Integrate_Adaptive(ab05, b, N, e);
        }
    }
}
