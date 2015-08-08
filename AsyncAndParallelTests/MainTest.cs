using AsyncAndParallel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests
{
    [TestFixture]
    class MainTest
    {
        [Test]
        public void main_run_0()
        {
            int expected = 0;

            int actual = Program.Main(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
