using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class FakeAsynchronusActionProvider : AsynchronusActionProvider
    {
        public FakeAsynchronusActionProvider(WaitingManager manager, TimeProvider provider) : base(manager)
        {
            this.TimeProvider = provider;
        }
    }
}
