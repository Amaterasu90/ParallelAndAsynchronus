using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class FakeTaskProvider : TaskProvider
    {
        private TaskProvider taskProvider;
        public FakeTaskProvider(TaskProvider provider, Task<long> task) : base(task)
        {
            taskProvider = provider;
        }

        public new String TaskCurrentIdToString
        {
            get { return taskProvider.TaskCurrentIdToString; }
        }

        public new Boolean TaskCurrentIdNotNull
        {
            get { return taskProvider.TaskCurrentIdNotNull; }
        }

        public new String PrintMessage
        {
            get { return taskProvider.PrintMessage; }
        }
    }
}
