using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class StreamPrinter
    {
        private static Stream stream = new MemoryStream();

        public static void SetStream(Stream stream)
        {
            StreamPrinter.stream = stream;
            StreamWriter writer = new StreamWriter(StreamPrinter.stream);
            Console.SetOut(writer);
        }
        public static void RewindStream()
        {
            stream.Position = 0;
        }
        public static void PrintMessage(String comunicate,String taskID)
        {
            String id = taskID.Equals(String.Empty) ? "UI" : taskID;
            PrintMessage(comunicate + " (" + id +")");
        }

        public static void PrintMessage(object owner, string comunicate)
        {
            Regex regex = new Regex(@"^(.*)\.");
            string Owner = regex.Replace(owner.ToString(),"");
            PrintMessage(Owner + " " + comunicate);
        }
        public static void PrintMessage(string comunicate)
        {
            Console.Out.WriteLine(comunicate);
            Console.Out.Flush();
        }
    }
}
