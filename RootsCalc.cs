using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba16
{
    public class RootsCalc
    {
        public static KeyValuePair<double, double> GetRoots(double a, double b, double c)
        {
            double D = b * b - 4 * a * c;
            if (D >= 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                return new KeyValuePair<double, double>(x1, x2);
            }
            else
            {
                return default;
            }
        }
    }
}
