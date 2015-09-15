using System;
using NUnit.Framework;

namespace AsyncAndParallelTests.Chapter1
{
    [TestFixture]
    public class ExpectStringMakerTest
    {
        private ExpectStringMaker _maker;
        private String _classToString;
        [SetUp]
        public void Initialize()
        {
            _classToString = "class";
            _maker = new ExpectStringMaker(_classToString);
        }
        [Test]
        public void AddNewLine_caonstructorClassString_ClassNameWithContentString()
        {
            String content = "content";
            String expected = _classToString + " " + content +"\r\n";

            _maker.addNewLine(content);

            String actual = _maker.GetResult();
            Assert.AreEqual(expected,actual);
        }
        [TearDown]
        public void Dispose()
        {
            _maker = null;
            _classToString = null;
        }
    }
}
