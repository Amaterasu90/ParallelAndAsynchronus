using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class AsynchronusActionTest
    {
        private AsynchronusAction _asynchronusAction;
        private MemoryStream _stream;
        private StreamReader _reader;
        private ExpectStringMaker _maker;
        private AsynchronusActionProvider _actionProvider;
        private WaitingManager _waitingManager;
        private Mock<TimeProvider> _mockTimeProvider;
        private String _asynchronusActionString;
        private String _asynchronusActionProviderString;

        [SetUp]
        public void Initialize()
        {
            _stream = new MemoryStream();
            StreamPrinter.SetStream(_stream);
            _reader = new StreamReader(_stream);

            _maker = new ExpectStringMaker();

            _waitingManager = new WaitingManager(100);
            _mockTimeProvider = new Mock<TimeProvider>();
            _actionProvider =new FakeAsynchronusActionProvider(_waitingManager,_mockTimeProvider.Object);
            _asynchronusAction = new FakeAsynchronusAction(_actionProvider);

            _asynchronusActionString = _asynchronusAction.ToString();
            _asynchronusActionProviderString = _actionProvider.ToString();
        }

        private String MakeExpectedString(int ticks)
        {
            makeBegin();
            _maker.addNewLine(_asynchronusActionProviderString, "Akcja: Początek, argument: asynchronicznie");
            _maker.addNewLine(_asynchronusActionProviderString, "Akcja: Koniec");
            _maker.addNewLine(_asynchronusActionString, "Wynik: " + ticks);
            makeEnd();
            return _maker.GetResult();
        }

        private void makeBegin()
        {
            _maker.addNewLine(_asynchronusActionString, "Akcja została uruchomiona");
            
        }

        private void makeEnd()
        {
            _maker.addNewLine(_asynchronusActionString, "RunOperations: Koniec");
        }

        private String MakeExpectedString()
        {
            makeBegin();
            _maker.addNewLine(_asynchronusActionString, "Zadanie nie zostało uruchomione");
            makeEnd();
            return _maker.GetResult();
        }

        [Test]
        public void Run_DateTimeTicks1TaskStatusRunning_ProperString()
        {
            int dateTimeTicks = 1;
            String expected = MakeExpectedString(dateTimeTicks);
            _mockTimeProvider.Setup(m => m.DateTimeTicks).Returns(dateTimeTicks);

            var task = _asynchronusAction.TaskInstance;
            _asynchronusAction.Run();
            task.Wait();

            StreamPrinter.RewindStream();
            String actual = _reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Run_TaskStatusCreated_ProperString()
        {
            String expected = MakeExpectedString();

            ((FakeAsynchronusAction)_asynchronusAction).RunOperations();

            StreamPrinter.RewindStream();
            String actual = _reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void Dispose()
        {
            this._maker = null;
            this._actionProvider = null;
            this._asynchronusAction = null;
            this._asynchronusActionProviderString = null;
            this._asynchronusActionString = null;
            this._mockTimeProvider = null;
            this._reader.Close();
            this._stream.Close();
            this._waitingManager = null;
        }
    }
}
