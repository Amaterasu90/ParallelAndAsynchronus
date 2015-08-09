using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._12_Przerywanie_pętli_równoległej
{
    public static class ParallelBreakCalculation
    {
        public static void BreakLoop()
        {
            Random r = new Random();
            long suma = 0;
            long licznik = 0;
            string s = "";

            Parallel.For(
                0,
                10000,
                (int i, ParallelLoopState stanPetli) =>
                {
                    int liczba = r.Next(7);
                    if(liczba == 0)
                    {
                        s += "0 (Stop)";
                        stanPetli.Stop();
                    }
                    if (stanPetli.IsStopped) return;
                    if(liczba % 2 == 0)
                    {
                        s += liczba.ToString() + ": ";
                        AsyncAndParallel.Chapter1.Listing1._9_Metoda_zajmująca_procesor.Math.obliczenia(liczba);
                        suma += liczba;
                        licznik += 1;
                    }
                    else
                    {
                        s += liczba.ToString() + ": ";
                    }
                });
            Console.WriteLine("Wylosowane liczby: " + s + "\n" 
                + "Liczba pasujacych liczb: " + licznik + "\n"
                + "Suma: " + suma + "\n"
                + "Średnia: " + (suma/(double)licznik).ToString() + "\n");
        }
    }
}
