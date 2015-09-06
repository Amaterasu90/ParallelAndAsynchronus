using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public class SynchronusActionProvider : ActionProvider
    {

        protected override void RunOperations(object argument)
        {
            StreamPrinter.PrintMessage("Akcja: Początek, argument: " + argument.ToString());
            WaitingManager.Sleep();
            StreamPrinter.PrintMessage("Akcja: Koniec");
        }

        public override Func<object, long> ActionDelegate
        {
            get
            {
                return (object argument) =>
                {
                    RunOperations(argument);
                    return DateTime.Now.Ticks;
                };
            }
        }

        public SynchronusActionProvider(WaitingManager manager) : base(manager)
        {
        }
    }
}
