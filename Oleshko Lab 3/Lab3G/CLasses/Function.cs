using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3G.CLasses
{
    public static class Function
    {
        public static double a = -2;
        public static double b = 5;
        public static int n = 20;
        public static double Evaluate(double x)
        {
            double y = 0.5 * (Math.Abs(x + 1) - Math.Abs(x - 2)) - x + 2;
            return y;
        }
        public static double NewtonEquidistant(double x)
        {
            double[] x_arr = new double[n];
            double[] y_arr = new double[n];
            double plus = (b - a) / ((n - 1) * 1.0);
            for (int i = 0; i < n; i++)
            {
                x_arr[i] = a + i * plus;
                y_arr[i] = Evaluate(x_arr[i]);
                //Debug.WriteLine(Math.Round(x_arr[i], 3) + " " + Math.Round(y_arr[i], 3));
            }
            return Newton(x, x_arr, y_arr);
        }
        public static double NewtonChebysh(double x)
        {
            double[] x_arr = new double[n];
            double[] y_arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                x_arr[i] = (a + b) / 2 + ((b - a) / 2) * Math.Cos((2 * i + 1) * Math.PI / (2 * n));
                y_arr[i] = Evaluate(x_arr[i]);
                //Debug.WriteLine(Math.Round(x_arr[i], 3) + " " + Math.Round(y_arr[i], 3));
            }
            return Newton(x, x_arr, y_arr);
        }
        public static double Newton(double x, double[] x_arr, double[] y_arr)
        {
            double sum = y_arr[0];
            for (int i = 1; i < n; ++i)
            {
                double F = 0;
                for (int j = 0; j <= i; ++j)
                {
                    double den = 1;
                    for (int k = 0; k <= i; ++k)
                        if (k != j)
                            den *= (x_arr[j] - x_arr[k]);
                    F += y_arr[j] / den;
                }

                for (int k = 0; k < i; ++k)
                    F *= (x - x_arr[k]);
                sum += F;
            }
            return sum;
        }
        public static double Spline(double x)
        {
            double y = 1000;
            if (-2 <= x && x <= -1.222)
            {
                y = 0.2807 * Math.Pow(x, 3) + 1.6839 * Math.Pow(x, 2) + 2.198 * x + 2.4055;
            }
            if (-1.222 < x && x <= -0.444)
            {
                y = -0.2226 * Math.Pow(x, 3) - 0.1608 * Math.Pow(x, 2) - 0.0563 * x + 1.4872;
            }
            if (-0.444 < x && x <= 0.333)
            {
                y = -0.0997 * Math.Pow(x, 3) + 0.0026 * Math.Pow(x, 2) + 0.0164 * x + 1.4961;
            }
            if (0.333 < x && x <= 1.111)
            {
                y = 0.15 * Math.Pow(x, 3) - 0.247 * Math.Pow(x, 2) + 0.0994 * x + 1.4887;
            }
            if (1.111 < x && x <= 1.889)
            {
                y = -0.5002 * Math.Pow(x, 3) + 1.92 * Math.Pow(x, 2) - 2.3081 * x + 2.3803;
            }
            if (1.889 < x && x <= 2.667)
            {
                y = 0.4344 * Math.Pow(x, 3) - 3.376 * Math.Pow(x, 2) + 7.696 * x - 3.9189;
            }
            if (2.667 < x && x <= 3.444)
            {
                y = -0.0545 * Math.Pow(x, 3) + 0.5349 * Math.Pow(x, 2) - 2.7338 * x + 5.3515;
            }
            if (3.444 < x && x <= 4.222)
            {
                y = 0.0149 * Math.Pow(x, 3) - 0.1816 * Math.Pow(x, 2) - 0.2661 * x + 2.5186;
            }
            if (4.222 < x && x <= 5)
            {
                y = -0.003 * Math.Pow(x, 3) + 0.0447 * Math.Pow(x, 2) - 1.2215 * x + 3.8632;
            }
            return y;
        }
        public static double Spline2(double x)
        {
            double y = 0;
            if (-2 <= x && x <= -0.25)
            {
                y = 0.065 * Math.Pow(x, 3) + 0.3898 * Math.Pow(x, 2) + 0.0093 * x + 1.479;
            }
            if (-0.25 <= x && x <= 1.5)
            {
                y = -0.1383 * Math.Pow(x, 3) + 0.2374 * Math.Pow(x, 2) - 0.0288 * x + 1.4758;
            }
            if (1.5 <= x && x <= 3.25)
            {
                y = 0.0683 * Math.Pow(x, 3) - 0.6922 * Math.Pow(x, 2) + 1.3656 * x + 0.7785;
            }
            if (3.25 <= x && x <= 5)
            {
                y = 0.005 * Math.Pow(x, 3) - 0.075 * Math.Pow(x, 2) - 0.6403 * x + 2.9516;
            }
            return y;
        }
    }
}
