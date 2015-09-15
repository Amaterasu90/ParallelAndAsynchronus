using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AsyncAndParallel.Chapter1
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
