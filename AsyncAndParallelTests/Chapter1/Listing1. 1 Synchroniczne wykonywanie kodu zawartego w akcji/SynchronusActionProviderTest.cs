using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;

namespace AsyncAndParallelTests.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    [TestFixture]
    public class SynchronusActionProviderTest : ActionProviderTest
    {
        [SetUp]
        public override void Initialize()
        {
            base.Initialize();

            ActionPrivider = new SynchronusActionProvider(WaitingManager.Object);
        }
        [Test]
        public override void invoke_defaultConstructor_printedProperString()
        {
            String argument = "default";
            String expected = "! Akcja: Początek, argument: " + argument + "\r\n" +
                              "! Akcja: Koniec\r\n";


            ActionPrivider.ActionDelegate.Invoke(argument);

            StreamPrinter.RewindStream();
            String actual = Reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public override void Dispose()
        {
            base.Dispose();
            ActionPrivider = null;
        }
    }
}
