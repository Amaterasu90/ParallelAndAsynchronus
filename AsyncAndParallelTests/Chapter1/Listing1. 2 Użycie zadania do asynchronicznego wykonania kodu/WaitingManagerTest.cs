using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class WaitingManagerTest
    {
        WaitingManager manager;
        [SetUp]
        public void initialize()
        {
            manager = new WaitingManager();
        }
        [Test]
        public void Sleep_defaultConstructor_TotalSleepTime100()
        {
            int expected = 100;

            manager.Sleep();

            int actual = manager.TotalSleepTime;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Sleep_100TimeSleep_ToalSleepTime10()
        {
            int expected = 100;
            manager = new WaitingManager(-1);

            manager.Sleep();

            int actual = manager.TotalSleepTime;
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void dispose()
        {
            manager = null;
        }
    }
}
