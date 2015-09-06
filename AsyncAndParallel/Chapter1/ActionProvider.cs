using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1
{
    public abstract class ActionProvider
    {
        protected TimeProvider TimeProvider;
        protected WaitingManager WaitingManager;
        public abstract Func<object, long> ActionDelegate { get; }

        protected void SetTimeProvider(TimeProvider provider)
        {
            this.TimeProvider = provider;
        }
        protected abstract void RunOperations(object argument);

        protected ActionProvider(WaitingManager manager)
        {
            this.WaitingManager = manager;

            TimeProvider = new TimeProvider();
        }
    }
}
