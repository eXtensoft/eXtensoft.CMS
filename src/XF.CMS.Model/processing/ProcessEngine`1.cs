using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public abstract class ProcessEngine<T> : IProcessEngine<T> where T : class, new()
    {
        public bool IsParallel { get; set; }
        public List<IProcessor<T>> Processors { get; set; }
        protected IProcessor<T> Chain { get; set; }


        bool IProcessEngine<T>.Initialize()
        {
            return Processors != null ? Initialize() : false;
        }

        void IProcessEngine<T>.Execute()
        {
            ExecuteStrategy();
        }

        void IProcessEngine<T>.Cleanup()
        {
            Cleanup();
        }

        public TailProcessor<T> Tail { get; set; }



        public virtual IDataServer<ProcessItem<T>> DataSource { get; set; }


        private Stopwatch timer;
        public Stopwatch Timer
        {
            get { return timer; }
            set { timer = value; }
        }


        protected virtual bool Initialize()
        {

            bool b = DataSource != null;

            b = b ? GenerateProcessorChain(Processors) : false;

            return b;
        }

        protected virtual void ExecuteStrategy()
        {
            Chain.Initialize();
            if (DataSource.Initialize())
            {
                if (IsParallel)
                {
                    ExecuteParallel();
                }
                else
                {
                    ExecuteSerial();
                }


            }
        }

        private void ExecuteSerial()
        {
            foreach (ProcessItem<T> item in DataSource)
            {
                Chain.Execute(item);
            }
        }

        private void ExecuteParallel()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 8;
            Parallel.ForEach(DataSource, options, Chain.Execute);
        }

        protected virtual void Cleanup()
        {
            Tail.BatchBlock.Complete();
            Tail.Insertion.Completion.Wait();

            DataSource.Cleanup();
            Chain.Cleanup();

            CleanupMetrics();

        }

       

        protected virtual bool GenerateProcessorChain(List<IProcessor<T>> processors)
        {
            bool b = true;
            List<IProcessor<T>> list = new List<IProcessor<T>>();
            for (int i = 0; i < processors.Count; i++)
            {
                IProcessor<T> p = processors[i];
                if (i > 0)
                {
                    list[i - 1].SetSuccessor(p);
                }

                string s = p.GetType().Name;
                if (s.Equals("TailProcessor", StringComparison.OrdinalIgnoreCase))
                {
                    Tail = p as TailProcessor<T>;
                }

                list.Add(p);

            }

            Chain = new HeadProcessor<T>();
            Chain.SetSuccessor(list[0]);


           
            return b;
        }


        private void CleanupMetrics()
        {

        }

    }
}
