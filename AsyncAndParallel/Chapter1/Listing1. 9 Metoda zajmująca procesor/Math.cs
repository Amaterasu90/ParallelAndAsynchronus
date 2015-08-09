using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._9_Metoda_zajmująca_procesor
{
    public static class Math
    {
        private static double _x;
        public static double obliczenia(double x)
        {
            for (int i = 0; i < 10; i++)
                _x = System.Math.Asin(System.Math.Sin(x));
            return _x;
        }
    }
}
