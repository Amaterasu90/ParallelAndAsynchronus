using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class TimeProviderTest
    {
        private TimeProvider timeProvider;
        [SetUp]
        public void initialize()
        {
            timeProvider = new TimeProvider(new DateTime());
        }
        [Test]
        public void TestMethod1()
        {
            long expected = new DateTime().Ticks;

            long actual = timeProvider.DateTimeTicks;

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void dispose()
        {

        }
    }
}
