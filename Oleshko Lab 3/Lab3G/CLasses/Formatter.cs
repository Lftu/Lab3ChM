using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3G.CLasses
{
    public static class Formatter
    {
        public static string GetDivideIterationInfo(int iterations, double minX, double maxX)
        {
            string iterationInfo = "Iteration " + (iterations + 1) + ", interval [" + minX + ";" + maxX + "]";
            return iterationInfo;
        }
        public static string GetSimpleIterationInfo(int iterations, double x)
        {
            string iterationInfo = "Iteration " + (iterations) + ", x = " + x;
            return iterationInfo;
        }
    }
}
