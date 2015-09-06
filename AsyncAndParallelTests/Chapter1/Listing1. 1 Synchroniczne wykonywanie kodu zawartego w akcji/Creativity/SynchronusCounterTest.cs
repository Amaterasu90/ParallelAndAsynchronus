using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallelTests.Chapter1.Creativity
{
    [TestFixture]
    class SynchronusCounterTest : SynchronusOperationTest
    {
        private FakeSynchronusCounter _defaultSynchronusCounter;
        private SynchronusActionProvider _provider;
        private WaitingManager _waitingManager;
        [SetUp]
        public void init()
        {
            _waitingManager = new WaitingManager();
            _provider = new SynchronusActionProvider(_waitingManager);
            _defaultSynchronusCounter = new FakeSynchronusCounter(_provider);
        }
        [Test]
        public void defaultConstructor_getTimestep_10()
        {
            int expected = 10;

            int actual = _defaultSynchronusCounter.TimeStep;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimeStep200_200()
        {
            int expected = 200;

            ((SynchronusCounter)_defaultSynchronusCounter).TimeStep = 200;

            int actual = ((FakeSynchronusCounter)_defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimestep0_1()
        {
            int expected = 1;

            ((SynchronusCounter)_defaultSynchronusCounter).TimeStep = 0;

            int actual = ((FakeSynchronusCounter)_defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimestepNegative1_1()
        {
            int expected = 1;

            ((SynchronusCounter)_defaultSynchronusCounter).TimeStep = -1;

            int actual = ((FakeSynchronusCounter)_defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        
    }
}
