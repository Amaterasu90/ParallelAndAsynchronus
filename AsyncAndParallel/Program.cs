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
            instance.makeThreadAction();

            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    Console.WriteLine("Jestem żywy...");
                else
                {
                    if (Console.ReadKey().Key == ConsoleKey.R)
                    {
                        break;
                    }
                }
            }

            AsynchronusOperation aInstance = new AsynchronusOperation();
            Console.WriteLine("Asynchronus run");
            aInstance.makeThreadAction();

            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    Console.WriteLine("Jestem żywy...");
                else
                {
                    if (Console.ReadKey().Key == ConsoleKey.R)
                    {
                        aInstance.printResult();
                        break;
                    }
                }
            }


            Console.ReadKey();

            return 0;
        }
    }
}
