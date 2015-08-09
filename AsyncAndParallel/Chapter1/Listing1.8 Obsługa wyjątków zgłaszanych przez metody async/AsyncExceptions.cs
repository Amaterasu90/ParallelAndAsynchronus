using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._8_Obsługa_wyjątków_zgłaszanych_przez_metody_async
{
    public class AsyncExceptions
    {
        public async void ProofOfAsyncWork()
        {
            printMessage("ProofOfAsyncWork: Początek");
            try
            {
                printMessage("ProofOfAsyncWork: Wynik: " + await AsyncOperation());
            }
            catch(Exception e)
            {
                printMessage("ProofOfAsyncWork: Błąd!\n" + e.Message);
            }
        }

        private async Task<long> AsyncOperation()
        {
            printMessage("AsyncOperation: Początek");
            long wynik = await AsyncAction("async/await");
            printMessage("AsyncOperation: Wynik: " + wynik.ToString());
            printMessage("AsyncOperation: Koniec");
            throw new Exception("nie udało się ]:-)");
            return wynik;
        }

        private Task<long> AsyncAction(string argument)
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

        private void printMessage(string p)
        {
            string taskID = Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "UI";
            Console.WriteLine("! " + p + "(" + taskID + ")");
        }
    }
}
