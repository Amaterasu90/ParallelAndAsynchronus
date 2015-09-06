using System;
using NUnit.Framework;
using AsyncAndParallel.Chapter1;
using AsyncAndParallelTests.Chapter1.Creativity;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;

namespace AsyncAndParallelTests
{
    [TestFixture]
    public class SynchronusOperationTest
    {
        protected SynchronusOperation defaultSynchronus;
        [SetUp]
        public void initialize()
        {
            defaultSynchronus = new FakeOperationSynchronus();
        }
        
        [TearDown]
        public void dispose()
        {
            defaultSynchronus = null;
        }
    }
}
