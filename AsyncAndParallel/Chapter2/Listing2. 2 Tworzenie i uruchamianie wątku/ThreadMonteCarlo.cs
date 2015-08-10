using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter2.Listing2._2_Tworzenie_i_uruchamianie_wątku
{
    public class ThreadMonteCarlo
    {
        private Random r = new Random();

        private double obliczPi(long iloscProb)
        {
            double x;
            double y;
            long iloscTrafien = 0;

            for (int i = 0; i < iloscProb; i++)
            {
                x = r.NextDouble();
                y = r.NextDouble();

                if (x * x + y * y < 1)
                    iloscTrafien++;
            }

            return 4.0 * iloscTrafien / iloscProb;
        }

        private void runCalculations()
        {
            int czasPoczatkowy = Environment.TickCount;
            Console.WriteLine("Uruchamianie obliczeń, wątek nr {0}...", Thread.CurrentThread.ManagedThreadId);

            long iloscProb = 100000000L;
            double pi = obliczPi(iloscProb: iloscProb);
            Console.WriteLine("Pi={0}, błąd={1}, wątek nr {2}", pi, Math.Abs(Math.PI - pi), 
                Thread.CurrentThread.ManagedThreadId);

            int czasKoncowy = Environment.TickCount;
            int roznica = czasKoncowy - czasPoczatkowy;
            Console.WriteLine("Czas obliczeń: " + (roznica).ToString());
        }

        public void run()
        {
            Thread thread = new Thread(runCalculations);
            thread.Start();
            Console.WriteLine("Czy ten napis pojawi sie przed otrzymaniem wątku? (tak)");
        }
    }
}
