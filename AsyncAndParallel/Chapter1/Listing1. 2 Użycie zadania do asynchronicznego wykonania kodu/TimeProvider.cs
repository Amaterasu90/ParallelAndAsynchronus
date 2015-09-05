using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class TimeProvider
    {
        private DateTime date;

        public TimeProvider():this(DateTime.Now)
        {
        }

        public TimeProvider(DateTime date)
        {
            this.date = date;
        }

        public virtual long DateTimeTicks{ 
            get { return date.Ticks; } 
        }
    }
}
