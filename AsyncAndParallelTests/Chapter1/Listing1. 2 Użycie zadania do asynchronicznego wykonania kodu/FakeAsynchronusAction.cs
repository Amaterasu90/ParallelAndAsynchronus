using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class FakeAsynchronusAction : AsynchronusAction
    {
        public FakeAsynchronusAction(AsynchronusActionProvider actionProvider) : base(actionProvider)
        {
        }

        public new void RunOperations()
        {
            base.RunOperations();
        }
    }
}
