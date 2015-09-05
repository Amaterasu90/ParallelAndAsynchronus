using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class FakeAsynchronusOperation : AsynchronusOperation
    {
        public StreamReader Reader
        {
            get {
                readFromStream();
                return reader; 
            }
        }

        private StreamReader reader;
        private Stream stream;

        public FakeAsynchronusOperation(WaitingManager manager, Stream stream, TimeProvider tProvider,
            TaskProvider taskManager) 
            : base(manager,stream)
        {
            this.stream = stream;
            base.tProvider = tProvider;
            base.taskManager = taskManager;
        }

        public new void Sleep()
        {
            base.Sleep();
        }

        public Boolean TaskCurrentIdNotNull
        {
            get { return base.taskCurrentIdNotNull; }
            set { base.taskCurrentIdNotNull = value; }
        }

        public new string getDataPrintMessage()
        {
            return base.getDataPrintMessage();
        }

        private void readFromStream()
        {
            stream.Position = 0;
            reader = new StreamReader(stream);
        }

        public new void printMessage(string komunikat)
        {
            base.printMessage(komunikat);
        }

        public new Func<object,long> createAction()
        {
            return base.createAction();
        }

        public new void runOperations(object argument)
        {
            base.runOperations(argument);
        }

        public new long DateTimeNowTicks
        {
            get { return base.DateTimeNowTicks; }
        }
    }
}
