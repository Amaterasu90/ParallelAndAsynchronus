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
        TaskProvider taskProvider;
        Mock<TaskProvider> mockProvider;
        TaskProvider provider;
        [SetUp]
        public void initialize()
        {
            Func<object, long> f = (object Arg) => { return 1; };
            Task<long> task = new Task<long>(f, "zadanie");
            provider = new TaskProvider(task);
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
    }
}
