using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusOperation : Operation
    {
        private TaskProvider _taskProvider;

        public AsynchronusOperation(AsynchronusActionProvider provider) : base(provider)
        {
            Provider = provider;
            var akcja = provider.ActionDelegate;
            var job = new Task<long>(akcja, "zadanie");
            _taskProvider = new TaskProvider(job);
        }

        protected void SetTaskProvider(TaskProvider taskProvider)
        {
            _taskProvider = taskProvider;
        }

        public override void RunAction()
        {
            _taskProvider.Start();
            StreamPrinter.PrintMessage("Start action: Początek", TaskProvider.getTaskCurrentIdToString());
            if (_taskProvider.Status != TaskStatus.Running &&
                _taskProvider.Status != TaskStatus.RanToCompletion)
                StreamPrinter.PrintMessage("Zadanie nie zostało uruchomione", TaskProvider.getTaskCurrentIdToString());
            else
                StreamPrinter.PrintMessage("Wynik: " + _taskProvider.Result, TaskProvider.getTaskCurrentIdToString());


            StreamPrinter.PrintMessage("Start action: Koniec", TaskProvider.getTaskCurrentIdToString());
        }
    }
}