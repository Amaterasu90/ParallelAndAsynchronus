using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1;
using AsyncAndParallelTests.Chapter1.Creativity;

namespace AsyncAndParallelTests
{
    [TestFixture]
    public class SynchronusOperationTest
    {
        protected SynchronusOperation defaultSynchronus;
        [SetUp]
        public void initialize()
        {
            defaultSynchronus = new FakeOperationSynchronus();
        }

        [Test]
        public void countElapsedTime_run_1000()
        {
            long expected = 100;

            long actual = defaultSynchronus.makeThreadAction();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void getDataPrintMessage_TaskCurrentIdHasValueFalse_stringUI()
        {
            string expected = "UI";
            ((FakeOperationSynchronus)defaultSynchronus).TaskCurrentIdNotNull = false;

            string actual = ((FakeOperationSynchronus)defaultSynchronus).getDataPrintMessage();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void getDataPrintMessage_TaskCurrentIdHasValueTrue_string1()
        {
            string expected = "1";
            ((FakeOperationSynchronus)defaultSynchronus).TaskCurrentIdNotNull = true;

            string actual = ((FakeOperationSynchronus)defaultSynchronus).getDataPrintMessage();

            Assert.AreEqual(expected, actual);
        }
        
        [TearDown]
        public void dispose()
        {
            defaultSynchronus = null;
        }
    }
}
