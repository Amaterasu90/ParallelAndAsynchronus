using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;
using System.IO;

namespace AsyncAndParallelTests.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    [TestFixture]
    public class SynchronusActionTest : IEqualsTest
    {
        private SynchronusAction _synchronusAction;
        private WaitingManager _waitingManager;
        private Mock<TimeProvider> _mockTimeProvider;
        private SynchronusActionProvider _synchronusActionProvider;
        private MemoryStream _stream;
        private StreamReader _reader;
        [SetUp]
        public void Initialize()
        {
            _stream = new MemoryStream();
            StreamPrinter.SetStream(_stream);
            _reader = new StreamReader(_stream);

            _mockTimeProvider = new Mock<TimeProvider>();
            _waitingManager = new WaitingManager();
            _synchronusActionProvider = new FakeSynchronusActionProvider(_mockTimeProvider.Object,_waitingManager);
            _synchronusAction = new FakeSynchronusAction(_synchronusActionProvider);
        }
        [Test]
        public void Run_CustomWaitingManager_ProperString()
        {
            int result = 1;
            _mockTimeProvider.Setup(m => m.DateTimeTicks).Returns(result);
            String expected = "Run: Początek\r\n" +
                              "Akcja: Początek, argument: synchronicznie\r\n" +
                              "Akcja: Koniec\r\n" +
                              "Wynik: " + result + "\r\n" +
                              "Run: Koniec\r\n";

            _synchronusAction.Run();

            StreamPrinter.RewindStream();
            String actual = _reader.ReadToEnd();
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Equals_nullArgument_false()
        {
            bool condition = _synchronusAction.Equals(null);

            Assert.False(condition);
        }
        [Test]
        public void Equals_notProperArgumentType_false()
        {
            bool condition = _synchronusAction.Equals(String.Empty);

            Assert.False(condition);
        }
        [Test]
        public void Equals_TheSameObject_true()
        {
            bool condition = _synchronusAction.Equals(_synchronusAction);

            Assert.True(condition);
        }
        [Test]
        public void Equals_NotEqualsArgument_false()
        {
            bool condition =
                _synchronusAction.Equals(new SynchronusAction(new SynchronusActionProvider(new WaitingManager(999))));

            Assert.False(condition);
        }

        [TearDown]
        public void Dispose()
        {
            this._synchronusAction = null;
            this._mockTimeProvider = null;
            this._stream.Close();
            this._reader.Close();
        }
    }
}
