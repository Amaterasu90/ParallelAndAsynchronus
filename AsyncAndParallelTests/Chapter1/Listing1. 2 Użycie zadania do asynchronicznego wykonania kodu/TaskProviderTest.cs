using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [TestFixture]
    public class TaskProviderTest
    {
        private Mock<TaskProvider> mockProvider;
        private TaskProvider provider;
        private Task<long> task;
        [SetUp]
        public void initialize()
        {
            Func<object, long> f = (object Arg) => { return 1; };
            task = new Task<long>(f, "zadanie");
            provider = new TaskProvider(task);

            object[] o = new object[]{task};
            mockProvider = new Mock<TaskProvider>(o);
        }
        [Test]
        public void Start_defaultConstructor_RunningTaskStatus()
        {
            TaskStatus expected = TaskStatus.Created;
            
            provider.Start();
            
            TaskStatus actual = provider.Status;
            Assert.AreNotEqual(expected, actual);
        }
        [Test]
        public void getStatus_defaultConstructor_TaskStatusCreated()
        {
            TaskStatus expected = TaskStatus.Created;

            TaskStatus actual = provider.Status;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void getResult_defaultConstructor_1()
        {
            long expected = 1;
            provider.Start();

            long actual = provider.Result;
            
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TaskCurrentIdToString_defaultConstructor_0()
        {
            String expected = String.Empty;

            String actual = provider.TaskCurrentIdToString;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void PrintMessage_TaskCurrentIdNotNullFalse_UIString()
        {
            String expected = "UI";
            mockProvider.Setup(m => m.TaskCurrentIdNotNull).Returns(false);
            FakeTaskProvider fakeProvider = new FakeTaskProvider(mockProvider.Object, task);

            String actual = fakeProvider.PrintMessage;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void PrintMessage_TaskCurrentIdNotNullTrue_null()
        {
            mockProvider.Setup(m => m.TaskCurrentIdNotNull).Returns(true);
            FakeTaskProvider fakeProvider = new FakeTaskProvider(mockProvider.Object, task);

            String anObject = fakeProvider.PrintMessage;

            Assert.Null(anObject);
        }

        [Test]
        public void TaskCurrentIdNotNull_defaultConstuctor_false()
        {
            bool expected = false;

            bool actual = this.provider.TaskCurrentIdNotNull;

            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void dispose()
        {
            this.mockProvider = null;
            this.provider = null;
        }
    }
}
