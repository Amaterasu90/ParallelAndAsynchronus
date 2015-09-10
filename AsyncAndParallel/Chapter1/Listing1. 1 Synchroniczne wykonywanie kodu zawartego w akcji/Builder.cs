using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._1_Synchroniczne_wykonywanie_kodu_zawartego_w_akcji
{
    public abstract class Builder
    {
        public abstract void CreateWaitingManager();

        public abstract void CreateActionProvider();

        public abstract void CreateAction();

        public virtual void build()
        {
            this.CreateWaitingManager();
            this.CreateActionProvider();
            this.CreateAction();
        }

        public abstract SynchronusAction getResult();
    }
}
