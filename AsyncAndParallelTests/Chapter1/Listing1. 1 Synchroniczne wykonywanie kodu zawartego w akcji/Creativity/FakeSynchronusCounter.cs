using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
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

        public FakeSynchronusCounter(SynchronusActionProvider provider) : base(provider)
        {
        }
    }
}
