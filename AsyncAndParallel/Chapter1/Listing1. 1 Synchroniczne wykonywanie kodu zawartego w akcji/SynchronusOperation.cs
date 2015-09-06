using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
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
    public class SynchronusOperation : Operation
    {
        private readonly SynchronusActionProvider _provider;
        public SynchronusOperation(SynchronusActionProvider provider) : base(provider)
        {
            this._provider = provider;
        }

        public override void RunAction()
        {
            StreamPrinter.PrintMessage("Start action: Początek");
            StreamPrinter.PrintMessage("Wynik: " + _provider.ActionDelegate("synchronicznie"));
            StreamPrinter.PrintMessage("Start action: Koniec");
        }
    }
}
