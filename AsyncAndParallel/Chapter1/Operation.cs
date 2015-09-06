using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1
{
    public abstract class Operation
    {
        protected ActionProvider Provider;
        public abstract void RunAction();

        protected Operation(ActionProvider provider)
        {
            Provider = provider;
        }
    }
}
