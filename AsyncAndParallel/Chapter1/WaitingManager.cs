using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class WaitingManager
    {
        public virtual int TotalSleepTime
        {
            get;
            private set;
        }

        public WaitingManager(int sleepTime)
        {
            this.TotalSleepTime = sleepTime;
        }

        public WaitingManager():this(100)
        {
        }

        public virtual void Sleep()
        {
            if (TotalSleepTime <= 0)
                TotalSleepTime = 100;
            Thread.Sleep(TotalSleepTime);
        }

        public override bool Equals(Object o)
        {
            if (o == null || !(o is WaitingManager))
                return false;
            WaitingManager waitingManager = o as WaitingManager;
            if (waitingManager.TotalSleepTime.Equals(TotalSleepTime))
                return true;
            return false;
        }
    }
}
