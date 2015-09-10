using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallelTests.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public class FakeSynchrousActionBuilder : SynchrousActionBuilder
    {
        public WaitingManager WaitingManager
        {
            get { return base._waitingManager; }
        }

        public SynchronusActionProvider SynchronusActionProvider
        {
            get { return base._synchronusActionProvider; }
        }

        public SynchronusAction SynchronusAction
        {
            get { return base._synchronusAction; }
        }
    }
}
