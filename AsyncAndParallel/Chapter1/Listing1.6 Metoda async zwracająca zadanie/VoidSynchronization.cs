using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._6_Metoda_async_zwracająca_zadanie
{
    public class VoidSynchronization
    {
        private async Task VoidAction()
        {
            printMessage("VoidAction: Początek");
            long wynik = await AsyncAction("async/await");
            printMessage("VoidAction: Wynik: " + wynik.ToString());
            printMessage("VoidAction: Koniec");
            return;
        }

        private Task<long> AsyncAction(object argument)
        {
            Func<object,long> akcja =
                (object _argument) =>
                {
                    printMessage("Akcja: Początek, argument" + _argument.ToString());
                    Thread.Sleep(1000);
                    printMessage("Akcja: Koniec");
                    return DateTime.Now.Ticks;
                };
            Task<long> zadanie = new Task<long>(akcja,argument);
            zadanie.Start();
            return zadanie;
        }

        public async void ProofOfAsyncWork()
        {
            printMessage("ProofOfAsyncWork: Początek");
            await VoidAction();
            printMessage("ProofOfAsyncWork: Koniec");
        }

        private void printMessage(string komunikat)
        {
            string taskID = Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "UI";
            Console.WriteLine("! " + komunikat + "( " + taskID + ")");
        }
    }
}
