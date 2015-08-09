using AsyncAndParallel.Chapter1.Listion1._10_Obliczenia_sekwencyjne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._11_Przykład_zrównoleglonej_pętli_for
{
    public static class ParallelCalculation
    {
        private static int rozmiar = 10000;

        public static int Rozmiar
        {
            get { return ParallelCalculation.rozmiar; }
            set { ParallelCalculation.rozmiar = value; }
        }
        private static Random r;
        private static int iloscPowtorzen = 100;

        public static int IloscPowtorzen
        {
            private get { return ParallelCalculation.iloscPowtorzen; }
            set { ParallelCalculation.iloscPowtorzen = value; }
        }

        public static void Calculations()
        {
            r = new Random();
            double[] tablica = new double[rozmiar];
            for (int powtorzenia = 0; powtorzenia < rozmiar; powtorzenia++)
                tablica[powtorzenia] = r.NextDouble();

            double[] wyniki = new double[tablica.Length];
            int start = System.Environment.TickCount;
            for (int powtorzenia = 0; powtorzenia < iloscPowtorzen; powtorzenia++)
                Parallel.For(0,tablica.Length,i=>
                {
                    wyniki[i] = AsyncAndParallel.Chapter1.Listing1._9_Metoda_zajmująca_procesor.
                        Math.obliczenia(tablica[i]);
                });
            int stop = System.Environment.TickCount;
            Console.WriteLine("Obliczenia sekwencyjne trwały " + (stop - start).ToString() + " ms.");
        }
    }
}
