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

        public FakeAsynchronusOperation(AsynchronusActionProvider provider,TaskProvider taskProvider) 
            : base(provider)
        {
            base.SetTaskProvider(taskProvider);
        }

        private void readFromStream()
        {
            stream.Position = 0;
            reader = new StreamReader(stream);
        }
    }
}
