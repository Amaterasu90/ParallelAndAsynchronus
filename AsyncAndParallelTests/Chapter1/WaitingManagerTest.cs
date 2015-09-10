using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using NUnit.Framework;

namespace AsyncAndParallelTests.Chapter1
{
    [TestFixture]
    public class WaitingManagerTest
    {
        private WaitingManager _manager;
        [SetUp]
        public void Initialize()
        {
            _manager = new WaitingManager();
        }
        [Test]
        public void Sleep_defaultConstructor_TotalSleepTime100()
        {
            int expected = 100;

            _manager.Sleep();

            int actual = _manager.TotalSleepTime;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Sleep_100TimeSleep_ToalSleepTime10()
        {
            int expected = 100;
            _manager = new WaitingManager(-1);

            _manager.Sleep();

            int actual = _manager.TotalSleepTime;
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void dispose()
        {
            _manager = null;
        }
    }
}
