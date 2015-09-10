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
                    return TimeProvider.DateTimeTicks;
                };
            }
        }

        public SynchronusActionProvider(WaitingManager manager) : base(manager)
        {
            this.TimeProvider = new TimeProvider();
        }

        public override bool Equals(Object o)
        {
            if (o != null && o is SynchronusActionProvider)
            {
                SynchronusActionProvider provider = o as SynchronusActionProvider;
                if (provider.WaitingManager.Equals(WaitingManager))
                    return true;
            }
            return false;
        }
    }
}
