using System;
using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel
{
    public class Program
    {
        public static int Main(string[] args)
        {
            AsynchronusAction asynchronusAction = new AsynchronusAction();
            asynchronusAction.Run();
            Console.ReadKey();

            return 0;
        }
    }
}
