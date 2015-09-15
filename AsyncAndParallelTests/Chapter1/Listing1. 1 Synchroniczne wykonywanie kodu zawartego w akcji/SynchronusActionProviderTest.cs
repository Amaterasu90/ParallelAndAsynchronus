using NUnit.Framework;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using System.IO;
using System;
using AsyncAndParallel.Chapter1;

namespace AsyncAndParallelTests.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{

    [TestFixture]
    public class SynchronusActionProviderTest : IEqualsTest
    {

        private Mock<WaitingManager> _mockWaitingManager;
        private SynchronusActionProvider _actionPrivider;
        private MemoryStream _stream;
        private StreamReader _reader;
        [SetUp]
        public void Initialize()
        {
            _stream = new MemoryStream();
            _reader = new StreamReader(_stream);
            StreamPrinter.SetStream(_stream);

            _mockWaitingManager = new Mock<WaitingManager>(new object[]{1000});
            _actionPrivider = new SynchronusActionProvider(_mockWaitingManager.Object);
        }
        [Test]
        public void ActionDelegate_Invoke_SleepWasCalled()
        {
            _mockWaitingManager.Setup(m=>m.Sleep()).Verifiable();

            _actionPrivider.ActionDelegate.Invoke("default");

            _mockWaitingManager.Verify(m=>m.Sleep(),Times.Once);
        }

        [Test]
        public void ActionDelegate_Invoke_ProperString()
        {
            String argument = "default";
            String expected = "Akcja: Początek, argument: " + argument + "\r\n" +
                              "Akcja: Koniec\r\n";

            _actionPrivider.ActionDelegate.Invoke(argument);

            StreamPrinter.RewindStream();
            String actual = _reader.ReadToEnd();
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Equals_nullArgument_false()
        {
            bool condition = _actionPrivider.Equals(null);

            Assert.False(condition);
        }

        [Test]
        public void Equals_notProperArgumentType_false()
        {
            bool condition = _actionPrivider.Equals(String.Empty);

            Assert.False(condition);
        }

        [Test]
        public void Equals_TheSameObject_true()
        {
            _mockWaitingManager.Setup(m => m.Equals(It.IsAny<object>())).Returns(true);

            bool condition = _actionPrivider.Equals(_actionPrivider);

            Assert.True(condition);
        }

        [Test]
        public void Equals_NotEqualsArgument_false()
        {
            bool condition = _actionPrivider.Equals(_actionPrivider);

            Assert.False(condition);
        }

        [TearDown]
        public void Dispose()
        {
            _actionPrivider = null;
            _mockWaitingManager = null;
        }
    }
}
