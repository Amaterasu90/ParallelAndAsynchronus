using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using AsyncAndParallel.Chapter1.Listing1._3_Wzór_metody_wykonującej_jakąś_czynność_asynchronicznie;
using AsyncAndParallel.Chapter1.Listing1._4_Przykład_użycia_modyfikatora_async_i_modyfikatora_await;
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
            AsyncAwaitExample asyncAwaitExample = new AsyncAwaitExample();
            for (int i = 0; i < 10; i++)
            {
                asyncAwaitExample.runAsyncTask();
                Console.WriteLine("Nie umarłem...");
            }

            Console.WriteLine("A teraz zmiana. Szpak dziobie bociana...");

            PatternAsynchronus patternAsynchronus = new PatternAsynchronus();
            for (int i = 0; i < 10; i++)
            {
                patternAsynchronus.runAsyncTask();
                Console.WriteLine("Nie umarłem...");
            }

                Console.ReadKey();
            return 0;
        }
    }
}
