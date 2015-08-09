using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._7_Metoda_async_zwracająca_wartość_long
{
    public class LongSynchronization
    {
        private async Task<long> AsyncOperation()
        {
            printMessage("AsyncOperation: Początek");
            long wynik = await AsyncAction("async/await");
            printMessage("AsyncOperation: Wynik: " + wynik.ToString());
            printMessage("AsyncOperation: Koniec");
            return wynik;
        }

        private Task<long> AsyncAction(object argument)
        {
            Func<object, long> akcja =
                (object _argument) =>
                {
                    printMessage("Akcja: Początek, argument" + _argument.ToString());
                    Thread.Sleep(1000);
                    printMessage("Akcja: Koniec");
                    return DateTime.Now.Ticks;
                };
            Task<long> zadanie = new Task<long>(akcja, argument);
            zadanie.Start();
            return zadanie;
        }

        private void printMessage(string komunikat)
        {
            string taskID = Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "UI";
            Console.WriteLine("! " + komunikat + "(" + taskID + ")");
        }

        public async void ProofAsyncWork()
        {
            printMessage("ProofOfAsyncWork: Początek");
            printMessage("ProofOfAsyncWork: Wynik: " + await AsyncOperation());
            printMessage("ProofOfAsyncWork: Koniec");
        }
    }
}