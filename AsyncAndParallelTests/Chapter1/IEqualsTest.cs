using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1
{
    public interface IEqualsTest
    {
        void Equals_nullArgument_false();
        void Equals_notProperArgumentType_false();
        void Equals_TheSameObject_true();
        void Equals_NotEqualsArgument_false();
    }
}
