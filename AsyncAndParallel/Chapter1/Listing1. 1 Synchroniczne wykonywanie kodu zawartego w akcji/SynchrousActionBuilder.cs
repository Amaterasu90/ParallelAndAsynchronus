using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public class SynchrousActionBuilder : Builder
    {
        protected SynchronusAction _synchronusAction;
        protected WaitingManager _waitingManager;
        protected SynchronusActionProvider _synchronusActionProvider;

        public override void CreateWaitingManager()
        {
            _waitingManager = new WaitingManager(1000);
        }

        public override void CreateActionProvider()
        {
            if(_waitingManager == null)
                CreateWaitingManager();
            _synchronusActionProvider = new SynchronusActionProvider(_waitingManager);
        }

        public override void CreateAction()
        {
            if(_synchronusActionProvider == null)
                CreateActionProvider();
            _synchronusAction = new SynchronusAction(_synchronusActionProvider);
        }

        public override SynchronusAction getResult()
        {
            return _synchronusAction;
        }
    }
}
