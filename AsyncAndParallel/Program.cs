using AsyncAndParallel.Chapter2.Listing2._1_Kod_Niezrównoleglony;
using AsyncAndParallel.Chapter2.Listing2._2_Tworzenie_i_uruchamianie_wątku;
using System;

namespace AsyncAndParallel
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Sequence");
            SequenceMonteCarlo sequenceMonteCarlo = new SequenceMonteCarlo();
            sequenceMonteCarlo.runCalculations();

            Console.WriteLine("Thread");
            ThreadMonteCarlo threadMonteCarlo = new ThreadMonteCarlo();
            threadMonteCarlo.run();

            Console.ReadKey();
            return 0;
        }
    }
}
