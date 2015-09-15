using System;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using NUnit.Framework;

namespace AsyncAndParallelTests.Chapter1
{
    [TestFixture]
    public class TimeProviderTest
    {
        private TimeProvider _timeProvider;
        [SetUp]
        public void Initialize()
        {
            _timeProvider = new TimeProvider(new DateTime());
        }
        [Test]
        public void DateTimeTicks_newDatetimeConstruct_Ticks0()
        {
            long expected = new DateTime().Ticks;

            long actual = _timeProvider.DateTimeTicks;

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void Dispose()
        {
            _timeProvider = null;
        }
    }
}
