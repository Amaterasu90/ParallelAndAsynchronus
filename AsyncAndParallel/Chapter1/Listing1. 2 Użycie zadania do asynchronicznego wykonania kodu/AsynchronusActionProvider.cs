using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusActionProvider : ActionProvider
    {
        private readonly TaskProvider _taskProvider;
        public AsynchronusActionProvider(WaitingManager manager,TaskProvider provider) : base(manager)
        {
            this._taskProvider = provider;
        }
        public override Func<object,long> ActionDelegate
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
            string taskId = _taskProvider.PrintMessage;
            StreamPrinter.PrintMessage("Akcja: Początek, argument: " + argument.ToString(),taskId);
            WaitingManager.Sleep();
            StreamPrinter.PrintMessage("Akcja: Koniec", taskId);
        }
    }
}
