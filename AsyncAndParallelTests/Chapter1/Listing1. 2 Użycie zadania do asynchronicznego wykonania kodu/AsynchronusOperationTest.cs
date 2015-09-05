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
        Mock<TimeProvider> provider;
        MemoryStream stream;
        Mock<TaskProvider> taskManager;
        [SetUp]
        public void initailize()
        {
            stream = new MemoryStream();
            provider = new Mock<TimeProvider>();
            manager = new Mock<WaitingManager>();
            Func<object, long> f = (object Arg)=>{return 1;};
            object[] o = new object[]{new Task<long>(f,"zadanie")};
            taskManager = new Mock<TaskProvider>(o);
            defaultAsynchronusOperation = new FakeAsynchronusOperation(manager.Object, stream, provider.Object,
                taskManager.Object);
        }

        [Test]
        public void Sleep_defaultWaitingManager_SleepWasCalled()
        {
            manager.Setup(m => m.Sleep()).Verifiable();

            defaultAsynchronusOperation.Sleep();

            manager.Verify(m => m.Sleep());
        }

        [Test]
        public void getDataPrintMessage_taskCurrentIdNotNullfalse_UIString()
        {
            String expected = "UI";
            defaultAsynchronusOperation.TaskCurrentIdNotNull = false;

            String actual = defaultAsynchronusOperation.getDataPrintMessage();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void getDataPrintMessage_taskCurrentIdNotNulltrue_notEmptyString()
        {
            defaultAsynchronusOperation.TaskCurrentIdNotNull = true;

            String anObject = defaultAsynchronusOperation.getDataPrintMessage();

            Assert.NotNull(anObject);
        }

        [Test]
        public void printMessage_taskCurrentIdNotNullfalse_Ciastek_UIString()
        {
            String message = "Ciastek";
            String expected = "! " + message + " (UI)";
            
            defaultAsynchronusOperation.printMessage(message);

            String actual = defaultAsynchronusOperation.Reader.ReadToEnd().Trim();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void createAction_defaultConstructor_notNull()
        {
            Func<object, long> anObject = defaultAsynchronusOperation.createAction();

            Assert.NotNull(anObject);
        }

        [Test]
        public void runOperations_argumentDefaultString_SleepWasCalled()
        {
            String argument = "default";
            manager.Setup(m => m.Sleep()).Verifiable();

            defaultAsynchronusOperation.runOperations(argument);

            manager.Verify(m => m.Sleep());
        }

        [Test]
        public void DateTimeNowTicks_defaultConstructor_100()
        {
            long expected = 100;
            provider.Setup(m => m.DateTimeTicks).Returns(100);

            long actual = defaultAsynchronusOperation.DateTimeNowTicks;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void runOperations_argumentDefaultString_Akcja_Poczatek_argument_default_UI_Akcja_KoniecString()
        {
            String argument = "default";
            String expected = "! Akcja: Początek, argument: " + argument +" (UI)\r\n! Akcja: Koniec (UI)\r\n";
            
            defaultAsynchronusOperation.runOperations(argument);
            
            String actual = defaultAsynchronusOperation.Reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void runThreadAction_argumentZadanieString_StartWasCalled()
        {
            taskManager.Setup(m => m.Start()).Verifiable();
            
            defaultAsynchronusOperation.runThreadAction();

            taskManager.Verify(m => m.Start());
        }

        [Test]
        public void reunThreadAction_taskStatusRunningFalseAndTaskStatusRanToComplectionFalse_ProperMessage()
        {
            taskManager.Setup(m => m.Status).Returns(TaskStatus.Created);
            String expected = "! Start action: Początek (UI)\r\n"
                + "! Zadanie nie zostało uruchomione (UI)\r\n"
                + "! Start action: Koniec (UI)\r\n";

            defaultAsynchronusOperation.runThreadAction();

            String actual = defaultAsynchronusOperation.Reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void reunThreadAction_taskStatusRunningTrue_ProperMessage()
        {
            long result = 1;
            taskManager.Setup(m => m.Status).Returns(TaskStatus.Running);
            taskManager.Setup(m => m.Result).Returns(result);
            String expected = "! Start action: Początek (UI)\r\n"
                + "! Wynik: "+ result +" (UI)\r\n"
                + "! Start action: Koniec (UI)\r\n";

            defaultAsynchronusOperation.runThreadAction();

            String actual = defaultAsynchronusOperation.Reader.ReadToEnd();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void createActionInvoke_defaultConstructor_100()
        {
            String argument = "default";
            long expected = 100;
            provider.Setup(m => m.DateTimeTicks).Returns(expected);

            long actual = defaultAsynchronusOperation.createAction().Invoke(argument);

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void dispose()
        {
            this.manager = null;
            this.provider = null;
            stream.Close();
            stream.Dispose();
        }
    }
}
