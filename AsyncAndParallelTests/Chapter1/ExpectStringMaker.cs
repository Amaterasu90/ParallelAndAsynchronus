using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Chapter1
{
    public class ExpectStringMaker
    {
        private String _result;
        private String _beginInfo;

        public void addNewLine(String content)
        {
            _result = _result + _beginInfo + " " + content +"\r\n";
        }

        public void addNewLine(String beginInfo, String content)
        {
            _result = _result + beginInfo + " " + content + "\r\n";
        }

        public ExpectStringMaker()
        {
            _result = String.Empty;
        }

        public ExpectStringMaker(String beginLineInfo)
        {
            _result = String.Empty;
            _beginInfo = beginLineInfo;
        }

        public String GetResult()
        {
            return _result;
        }
    }
}
