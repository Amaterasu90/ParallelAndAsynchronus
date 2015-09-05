using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallelTests.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    [assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
    public interface IThreadService
    {
        void Sleep(int interval);
    }
}
