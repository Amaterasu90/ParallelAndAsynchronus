﻿using AsyncAndParallel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1
{
    public class SynchronusCounter : SynchronusOperation
    {
        protected int timeStep = 10;

        public int TimeStep
        {
            set
            {
                Debug.Print(TagContainer.synchronusCounting, "Time step is less or equal 0. Timestep was set on 1");
                bool isLessOrEqualZero = value <= 0;
                timeStep = isLessOrEqualZero ? 1 : value;
            }
        }

        protected override void threadOperations()
        {
            for (int elapsedTime = 0; elapsedTime < SynchronusCounter.totalSleepTime; elapsedTime += timeStep)
            {
                Thread.Sleep(timeStep);
                printElapsedTime(elapsedTime);
            }
        }

        public int countElapsedTime()
        {
            return base.makeThreadAction();
        }

        private void printElapsedTime(int time)
        {
            Console.WriteLine("Synchronus (blocking) elapsed time: " + time);
        }
    }
}
