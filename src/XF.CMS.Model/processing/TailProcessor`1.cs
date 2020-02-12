using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Conserver
{
    public class TailProcessor<T> : Processor<T> where T : class, new()
    {


        public BatchBlock<ProcessItem<T>> BatchBlock { get; set; }

        public ActionBlock<IEnumerable<ProcessItem<T>>> Insertion { get; set; }


        protected override void Execute(ProcessItem<T> item)
        {

            BatchBlock.Post(item);

        }

        protected override bool Initialize()
        {
            return InitializeProcessor();
        }
        protected virtual bool InitializeProcessor()
        {
            return true;
        }

        protected override void Cleanup()
        {
            CleanupProcessor();
        }

        protected virtual void CleanupProcessor()
        {
        }
    }
}
