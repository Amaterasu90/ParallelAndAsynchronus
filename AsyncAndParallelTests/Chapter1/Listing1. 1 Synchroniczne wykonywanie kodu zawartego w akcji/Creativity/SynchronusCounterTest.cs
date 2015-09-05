using AsyncAndParallel.Chapter1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Creativity
{
    [TestFixture]
    class SynchronusCounterTest : SynchronusOperationTest
    {
        SynchronusCounter defaultSynchronusCounter;
        [SetUp]
        public void init()
        {
            defaultSynchronusCounter = new FakeSynchronusCounter();
        }
        [Test]
        public void defaultConstructor_getTimestep_10()
        {
            int expected = 10;

            int actual = ((FakeSynchronusCounter)defaultSynchronusCounter).TimeStep;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimeStep200_200()
        {
            int expected = 200;

            ((SynchronusCounter)defaultSynchronusCounter).TimeStep = 200;

            int actual = ((FakeSynchronusCounter)defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimestep0_1()
        {
            int expected = 1;

            ((SynchronusCounter)defaultSynchronusCounter).TimeStep = 0;

            int actual = ((FakeSynchronusCounter)defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void setTimeStep_setTimestepNegative1_1()
        {
            int expected = 1;

            ((SynchronusCounter)defaultSynchronusCounter).TimeStep = -1;

            int actual = ((FakeSynchronusCounter)defaultSynchronusCounter).TimeStep;
            Assert.AreEqual(expected, actual);
        }

        
    }
}
