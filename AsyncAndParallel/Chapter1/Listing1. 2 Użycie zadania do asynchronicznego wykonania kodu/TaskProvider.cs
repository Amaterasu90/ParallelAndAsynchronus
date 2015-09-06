using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class TaskProvider
    {
        private Task<long> job;
        public TaskProvider(Task<long> task)
        {
            job = task;
        }

        public virtual void Start()
        {
            job.Start();
        }

        public virtual TaskStatus Status
        {
            get { return job.Status; }
        }

        public virtual long Result
        {
            get { return job.Result; }
        }

        public virtual Boolean TaskCurrentIdNotNull
        {
            get { return TaskProvider.STaskCurrentIdNotNull; }
        }

        public virtual String TaskCurrentIdToString
        {
            get { return TaskProvider.getTaskCurrentIdToString(); }
        }
        public string PrintMessage
        {
            get { return this.TaskCurrentIdNotNull ? this.TaskCurrentIdToString : "UI"; }
        }

        private static Boolean STaskCurrentIdNotNull
        {
            get { return Task.CurrentId.HasValue; }
        }

        public static String getTaskCurrentIdToString()
        {
            return Task.CurrentId.ToString();
        }
    }
}
