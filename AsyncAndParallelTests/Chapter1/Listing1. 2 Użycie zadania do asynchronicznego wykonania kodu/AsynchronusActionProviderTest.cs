using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class AsynchronusActionProviderTest : ActionProviderTest
    {
        private Mock<TaskProvider> _taskProvider;

        [SetUp]
        public override void Initialize()
        {
            base.Initialize();

            Func<object, long> f = (object argument) => { return 1; };
            Task<long> task = new Task<long>(f, "default");
            object[] o = new object[] { task };
            _taskProvider = new Mock<TaskProvider>(o);

            ActionPrivider = new AsynchronusActionProvider(WaitingManager.Object, _taskProvider.Object);
        }

        [Test]
        public override void invoke_defaultConstructor_printedProperString()
        {
            String argument = "default";
            String expected = "! Akcja: Początek, argument: " + argument + " (UI)\r\n" +
                "! Akcja: Koniec (UI)\r\n";

            ActionPrivider.ActionDelegate.Invoke(argument);

            StreamPrinter.RewindStream();
            String actual = Reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public override void Dispose()
        {
            base.Dispose();
            _taskProvider = null;
        }
    }
}
