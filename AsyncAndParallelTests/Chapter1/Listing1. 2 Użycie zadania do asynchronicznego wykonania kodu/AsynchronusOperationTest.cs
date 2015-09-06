using System;
using NUnit.Framework;
using Moq;
using System.ComponentModel;
using Microsoft.Practices.Unity;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System.Runtime.CompilerServices;
using System.Threading;
using AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class AsynchronusOperationTest
    {
        FakeAsynchronusOperation defaultAsynchronusOperation;
        Mock<WaitingManager> manager;
        Mock<TaskProvider> taskProvider;
        Mock<TimeProvider> timeProvider;
        FakeActionProvider actionProvider;
        MemoryStream stream;
        StreamReader reader;
        [SetUp]
        public void initailize()
        {
            stream = new MemoryStream();
            reader = new StreamReader(stream);
            StreamPrinter.SetStream(stream);
            
            manager = new Mock<WaitingManager>();
            timeProvider = new Mock<TimeProvider>();

            Func<object, long> f = (object argument) => { return 1; };
            Task<long> task = new Task<long>(f, "default");
            object[] o = new object[] { task };
            taskProvider = new Mock<TaskProvider>(o);
            
            actionProvider = new FakeActionProvider(manager.Object,taskProvider.Object,timeProvider.Object);
            defaultAsynchronusOperation = new FakeAsynchronusOperation(actionProvider,taskProvider.Object);
        }

        private void Rewind(Stream stream)
        {
            stream.Position = 0;
        }

        [Test]
        public void runThreadAction_dateTimeTicks1TaskStatusRunning_properString()
        {
            int dateTime = 1;
            String expected = "! Start action: Początek (UI)\r\n" +
                "! Wynik: 1 (UI)\r\n" +
                "! Start action: Koniec (UI)\r\n";

            taskProvider.Setup(m => m.Result).Returns(dateTime);
            taskProvider.Setup(m => m.Status).Returns(TaskStatus.Running);

            defaultAsynchronusOperation.RunAction();

            Rewind(stream);
            String actual = reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void runThreadAction_dateTimeTicks1TaskStatusCreated_properString()
        {
            String expected = "! Start action: Początek (UI)\r\n" +
                "! Zadanie nie zostało uruchomione (UI)\r\n" +
                "! Start action: Koniec (UI)\r\n";
            taskProvider.Setup(m => m.Status).Returns(TaskStatus.Created);

            defaultAsynchronusOperation.RunAction();

            Rewind(stream);
            String actual = reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void dispose()
        {
            this.manager = null;
        }
    }
}
