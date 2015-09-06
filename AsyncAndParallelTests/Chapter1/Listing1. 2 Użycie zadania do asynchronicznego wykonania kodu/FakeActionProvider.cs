using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class FakeActionProvider : AsynchronusActionProvider
    {
        public FakeActionProvider(WaitingManager waitingManager, TaskProvider taskProvider, 
            TimeProvider timeProvider) : base(waitingManager,taskProvider)
        {
            base.SetTimeProvider(timeProvider);
        }
    }
}
