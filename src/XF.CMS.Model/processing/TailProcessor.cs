using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Conserver
{
    public class TailProcessor : TailProcessor<Metadata>
    {

        protected override bool Initialize()
        {
            BatchBlock = new BatchBlock<ProcessItem<Metadata>>(5);
            Insertion = new ActionBlock<IEnumerable<ProcessItem<Metadata>>>(a => ExecuteInserts(a));
            BatchBlock.LinkTo(Insertion);
            BatchBlock.Completion.ContinueWith(delegate { Insertion.Complete(); });

            return true;
        }

        private void ExecuteInserts(IEnumerable<ProcessItem<Metadata>> items)
        {
        }
    }
}
