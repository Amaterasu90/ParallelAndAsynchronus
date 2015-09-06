using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using AsyncAndParallel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public class SynchronusCounter : SynchronusOperation
    {
        protected int timeStep = 10;
        private static int TotalSleepTime = 100;

        public int TimeStep
        {
            set
            {
                Debug.Print(TagContainer.synchronusCounting, "Time step is less or equal 0. Timestep was set on 1");
                bool isLessOrEqualZero = value <= 0;
                timeStep = isLessOrEqualZero ? 1 : value;
            }
        }

        protected void ThreadOperations()
        {
            for (int elapsedTime = 0; elapsedTime < SynchronusCounter.TotalSleepTime; elapsedTime += timeStep)
            {
                Thread.Sleep(timeStep);
                printElapsedTime(elapsedTime);
            }
        }

        private void printElapsedTime(int time)
        {
            Console.WriteLine("Synchronus (blocking) elapsed time: " + time);
        }

        public SynchronusCounter(SynchronusActionProvider provider) : base(provider)
        {
        }
    }
}
