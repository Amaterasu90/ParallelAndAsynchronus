using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusActionProvider : ActionProvider
    {
        public AsynchronusActionProvider(WaitingManager manager) : base(manager)
        {
            this.TimeProvider = new TimeProvider();
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

        protected override void RunOperations(object argument)
        {
            StreamPrinter.PrintMessage(this, "Akcja: Początek, argument: " + argument.ToString());
            WaitingManager.Sleep();
            StreamPrinter.PrintMessage(this, "Akcja: Koniec");
        }

        public override String ToString()
        {
            return "AsynchronusActionProvider";
        }
    }
}
