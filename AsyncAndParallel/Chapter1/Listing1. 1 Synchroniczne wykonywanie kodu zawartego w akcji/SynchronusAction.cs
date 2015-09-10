using System;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public class SynchronusAction
    {
        private static readonly String Argument = "synchronicznie";
        private readonly SynchronusActionProvider _synchronusActionProvider;

        public SynchronusAction(SynchronusActionProvider provider)
        {
            _synchronusActionProvider = provider;
        }

        public void Run()
        {
            Func<object, long> action = _synchronusActionProvider.ActionDelegate;

            StreamPrinter.PrintMessage("Run: Początek");
            StreamPrinter.PrintMessage("Wynik: "+action(Argument));
            StreamPrinter.PrintMessage("Run: Koniec");
        }

        public override bool Equals(Object o)
        {
            if (o != null && o is SynchronusAction)
            {
                SynchronusAction action = o as SynchronusAction;
                if (action._synchronusActionProvider.Equals(_synchronusActionProvider))
                    return true;
            }
            return false;
        }
    }
}
