using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using AsyncAndParallel.Chapter1.Listing1._3_Wzór_metody_wykonującej_jakąś_czynność_asynchronicznie;
using AsyncAndParallel.Chapter1.Listing1._4_Przykład_użycia_modyfikatora_async_i_modyfikatora_await;
using AsyncAndParallel.Chapter1.Listing1._5_Działanie_modyfikatora_async;
using AsyncAndParallel.Chapter1.Listing1._6_Metoda_async_zwracająca_zadanie;
using AsyncAndParallel.Chapter1.Listing1._7_Metoda_async_zwracająca_wartość_long;
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
            LongSynchronization longSynchronization = new LongSynchronization();
            longSynchronization.ProofAsyncWork();

            Console.ReadKey();
            return 0;
        }
    }
}
