using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter2.Listing2._1_Kod_Niezrównoleglony
{
    public class SequenceMonteCarlo
    {
        private Random r = new Random();

        private double obliczPi(long iloscProb)
        {
            double x;
            double y;
            long iloscTrafien = 0;
            
            for(int i = 0; i < iloscProb; i++)
            {
                x = r.NextDouble();
                y = r.NextDouble();
                
                if (x * x + y * y < 1)
                    iloscTrafien++;
            }

            return 4.0 * iloscTrafien / iloscProb;
        }

        public void runCalculations()
        {
            int czasPoczatkowy = Environment.TickCount;

            long iloscProb = 100000000L;
            double pi = obliczPi(iloscProb: iloscProb);
            Console.WriteLine("Pi={0}, błąd={1}", pi, Math.Abs(Math.PI - pi));

            int czasKoncowy = Environment.TickCount;
            int roznica = czasKoncowy - czasPoczatkowy;
            Console.WriteLine("Czas obliczeń: " + (roznica).ToString());
        }
    }
}
