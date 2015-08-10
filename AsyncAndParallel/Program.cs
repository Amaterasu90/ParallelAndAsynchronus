using AsyncAndParallel.Chapter1.Listing1._11_Przykład_zrównoleglonej_pętli_for;
using AsyncAndParallel.Chapter1.Listing1._12_Przerywanie_pętli_równoległej;
using AsyncAndParallel.Chapter1.Listing1._10_Obliczenia_sekwencyjne;
using System;
using AsyncAndParallel.Chapter2.Listing2._1_Kod_Niezrównoleglony;

namespace AsyncAndParallel
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Sequence");
            SequenceMonteCarlo sequenceMonteCarlo = new SequenceMonteCarlo();
            sequenceMonteCarlo.runCalculations();

            Console.ReadKey();
            return 0;
        }
    }
}
