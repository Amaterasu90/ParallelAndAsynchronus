using System;
using System.IO;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using AsyncAndParallel.Chapter1;

namespace AsyncAndParallelTests.Chapter1
{
    [TestFixture]
    public abstract class ActionProviderTest
    {
        protected ActionProvider ActionPrivider;
        protected Mock<WaitingManager> WaitingManager;
        protected MemoryStream Stream;
        protected StreamReader Reader;
        public abstract void invoke_defaultConstructor_printedProperString();

        [SetUp]
        public virtual void Initialize()
        {
            Stream = new MemoryStream();
            StreamPrinter.SetStream(Stream);
            Reader = new StreamReader(Stream);

            WaitingManager = new Mock<WaitingManager>();
        }

        [TearDown]
        public virtual void Dispose()
        {
            this.WaitingManager = null;
            this.ActionPrivider = null;
            this.Reader.Close();
            this.Stream.Close();
        }
    }
}
