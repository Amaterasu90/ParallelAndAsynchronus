using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusOperation
    {
        protected TimeProvider tProvider;

        private WaitingManager wManager;
        private Stream stream;

        protected bool taskCurrentIdNotNull = Task.CurrentId.HasValue;
        protected string taskCurrentIdToString = Task.CurrentId.ToString();

        protected TaskProvider taskManager;
        public AsynchronusOperation(WaitingManager manager, Stream stream)
        {
            wManager = manager;
            this.stream = stream;
            StreamWriter writer = new StreamWriter(this.stream);
            Console.SetOut(writer);

            tProvider = new TimeProvider();
            
            Func<object, long> akcja = createAction();
            Task<long> job = new Task<long>(akcja, "zadanie");
            taskManager = new TaskProvider(job);
        }
        protected Func<object,long> createAction()
        {
            return (object argument) =>
                {
                    runOperations(argument);
                    return DateTimeNowTicks;
                };
        }
        protected void runOperations(object argument)
        {
            printMessage("Akcja: Początek, argument: " + argument.ToString());
            Sleep();
            printMessage("Akcja: Koniec");
        }
        protected long DateTimeNowTicks
        {
            get { return tProvider.DateTimeTicks; }
        }

        public void runThreadAction()
        {
            taskManager.Start();
            printMessage("Start action: Początek");
            if (taskManager.Status != TaskStatus.Running &&
                taskManager.Status != TaskStatus.RanToCompletion)
                printMessage("Zadanie nie zostało uruchomione");
            else
                printMessage("Wynik: " + taskManager.Result);


            printMessage("Start action: Koniec");
        }
        protected string getDataPrintMessage()
        {
            return taskCurrentIdNotNull ? taskCurrentIdToString : "UI";
        }

        protected void printMessage(String komunikat)
        {
            string taskID = getDataPrintMessage();
            Console.Out.WriteLine("! " + komunikat + " (" + taskID + ")");
            Console.Out.Flush();
        }

        protected void Sleep()
        {
            wManager.Sleep();
        }
    }
}
