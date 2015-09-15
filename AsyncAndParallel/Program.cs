﻿using System;
using AsyncAndParallel.Chapter1;
using AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;
using AsyncAndParallel.Chapter1.Listing1._3_Wzór_metody_wykonującej_jakąś_czynność_asynchronicznie;

namespace AsyncAndParallel
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ImprovementAsynchronusOperation operation = new ImprovementAsynchronusOperation(new WaitingManager(1000));
            operation.Run();
            Console.ReadKey();
            return -1;
        }
    }
}
