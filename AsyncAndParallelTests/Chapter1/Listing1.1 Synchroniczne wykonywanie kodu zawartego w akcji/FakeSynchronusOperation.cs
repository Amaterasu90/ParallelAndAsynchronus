using AsyncAndParallel.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests
{
    class FakeOperationSynchronus : SynchronusOperation
    {
        public FakeOperationSynchronus()
        {
            this.taskCurrentIdToString = "1";
        }

        public bool TaskCurrentIdNotNull
        {
            get { return this.taskCurrentIdNotNull; }
            set { this.taskCurrentIdNotNull = value; }
        }

        public new string getDataPrintMessage()
        {
            return base.getDataPrintMessage();
        }
    }
}
