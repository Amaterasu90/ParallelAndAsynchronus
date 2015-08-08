using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel
{
    public class Program
    {
        public static int Main(string[] args)
        {
            SynchronusOperation instance = new SynchronusOperation();
            Console.WriteLine("Synchronus run");

            for (int i = 0; i < 100; i++)
            {
                instance.makeThreadAction();
                Console.WriteLine("I'm alive...");
            }

            AsynchronusOperation aInstance = new AsynchronusOperation();
            Console.WriteLine("Asynchronus run");

                aInstance.makeThreadAction();
                Console.WriteLine("I'm alive...");

                aInstance.makeThreadAction();
                Console.WriteLine("I'm alive...");
            Console.ReadKey();

            return 0;
        }
    }
}
