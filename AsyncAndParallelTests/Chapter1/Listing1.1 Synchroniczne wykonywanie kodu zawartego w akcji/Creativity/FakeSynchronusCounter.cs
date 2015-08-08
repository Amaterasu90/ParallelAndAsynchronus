﻿using AsyncAndParallel.Chapter1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Creativity
{
    class FakeSynchronusCounter : SynchronusCounter
    {
        public new int TimeStep
        {
            get { return base.timeStep; }
            set { base.timeStep = value; }
        }
        
        private readonly FakeOperationSynchronus fakeOperationSynchronus = 
            new FakeOperationSynchronus();
            
        public new string getDataPrintMessage()
        {
            return fakeOperationSynchronus.getDataPrintMessage();
        }

        public bool TaskCurrentIdNotNull
        {
            get
            {
                return base.taskCurrentIdNotNull;
            }
            set
            {
                base.taskCurrentIdNotNull = value;
            }
        }
    }
}