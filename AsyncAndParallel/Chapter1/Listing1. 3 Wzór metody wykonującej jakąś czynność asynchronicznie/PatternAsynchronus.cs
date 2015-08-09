using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._3_Wzór_metody_wykonującej_jakąś_czynność_asynchronicznie
{
    class PatternAsynchronus
    {
        private Task<long> AsynchronusAct(object argument)
        {
            Func<object, long> akcja =
                (object _argument) =>
                {
                    printMessage("Akcja: Początek, argument: " + _argument.ToString());
                    Thread.Sleep(1000);
                    printMessage("Akcja Koniec");
                    return DateTime.Now.Ticks;
                };

            Task<long> zadanie = new Task<long>(akcja,argument);
            zadanie.Start();
            return zadanie;
        }

        private void printMessage(string messageContent)
        {
            Console.WriteLine(messageContent);
        }

        public void runAsyncTask()
        {
            printMessage("runAsyncTask PatternAsynchronus: Początek");
            Task<long> zadanie = AsynchronusAct("zadanie-metoda");
            printMessage("runAsyncTask PatternAsynchronus: Akcja została uruchomiona");
            if (zadanie.Status != TaskStatus.Running && zadanie.Status != TaskStatus.RanToCompletion)
                printMessage(" runAsyncTask PatternAsynchronus: Zadanie nie zostało uruchomione");
            else
                printMessage("runAsyncTask PatternAsynchronus: Wynik: " + zadanie.Result);
            printMessage("runAsyncTask PatternAsynchronus: Koniec");
        }
    }
}
