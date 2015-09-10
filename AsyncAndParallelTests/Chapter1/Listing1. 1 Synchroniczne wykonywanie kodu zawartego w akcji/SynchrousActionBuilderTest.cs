using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallelTests.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    [TestFixture]
    public class SynchrousActionBuilderTest
    {
        private Builder builder;
        private WaitingManager waitingManager;
        private SynchronusActionProvider synchronusActionProvider;
        private SynchronusAction synchronusAction;
        [SetUp]
        public void Initialize()
        {
            builder = new FakeSynchrousActionBuilder();
            waitingManager = new WaitingManager(1000);
            synchronusActionProvider = new SynchronusActionProvider(waitingManager);
            synchronusAction = new SynchronusAction(synchronusActionProvider);
        }
        [Test]
        public void CreateWaitingManager_DefaultConstructor_WaitingManagerSleepTime1000()
        {
            WaitingManager expected = waitingManager;

            builder.CreateWaitingManager();

            WaitingManager actual = ((FakeSynchrousActionBuilder) builder).WaitingManager;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateProvider_CreateWaitingManagerCall_ProperSynchronusProvider()
        {
            SynchronusActionProvider expected = synchronusActionProvider;
            
            builder.CreateWaitingManager();
            builder.CreateActionProvider();

            SynchronusActionProvider actual = ((FakeSynchrousActionBuilder) builder).SynchronusActionProvider;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void CreateProvider_CreateWaitingManagerNotCall_ProperSynchronusProvider()
        {
            SynchronusActionProvider expected = synchronusActionProvider;

            builder.CreateActionProvider();

            SynchronusActionProvider actual = ((FakeSynchrousActionBuilder)builder).SynchronusActionProvider;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateAction_CreateWaitingManagerNotCallCreateActionProviderCall_Action()
        {
            SynchronusAction expected = new SynchronusAction(synchronusActionProvider);

            builder.CreateActionProvider();
            builder.CreateAction();

            SynchronusAction actual = ((FakeSynchrousActionBuilder)builder).SynchronusAction;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateAction_CreateWaitingManagerNotCallCreateActionProviderNotCall_Action()
        {
            SynchronusAction expected = new SynchronusAction(synchronusActionProvider);

            builder.CreateAction();

            SynchronusAction actual = ((FakeSynchrousActionBuilder)builder).SynchronusAction;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateAction_CreateWaitingManagerCallCreateActionProviderCall_Action()
        {
            SynchronusAction expected = new SynchronusAction(synchronusActionProvider);

            builder.CreateWaitingManager();
            builder.CreateActionProvider();
            builder.CreateAction();

            SynchronusAction actual = ((FakeSynchrousActionBuilder) builder).SynchronusAction;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetResult_CreateWaitingManagerNotCallCreateActionProviderNotCallCreateActionNotCall_Null()
        {
            SynchronusAction anObject = builder.getResult();
            
            Assert.Null(anObject);
        }

        [Test]
        public void GetResult_CreateWaitingManagerCallCreateActionProviderNotCallCreateActionNotCall_Null()
        {
            builder.CreateWaitingManager();

            SynchronusAction anObject = builder.getResult();

            Assert.Null(anObject);
        }

        [Test]
        public void GetResult_CreateWaitingManagerCallCreateActionProviderCallCreateActionNotCall_Null()
        {
            builder.CreateActionProvider();

            SynchronusAction anObject = builder.getResult();

            Assert.Null(anObject);
        }

        [Test]
        public void Build_DefaultConstructor_NotNullProduct()
        {
            builder.build();

            SynchronusAction anObject = builder.getResult();
            Assert.NotNull(anObject);
        }

        [Test]
        public void GetResult_CreateWaitingManagernotCallCreateActionProviderNotCallCreateActionCall_ProperSynchonizeAction()
        {
            SynchronusAction expected = synchronusAction;
            builder.CreateAction();

            SynchronusAction actual = builder.getResult();

            Assert.AreEqual(expected,actual);
        }
    }
}
