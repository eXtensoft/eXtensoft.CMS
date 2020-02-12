using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public class GroupProcessor : Processor<Metadata>
    {
        protected override void Execute(ProcessItem<Metadata> item)
        {
            Console.WriteLine($"database-processor-{++Index}  item-{item.Index}");
        }
    }
}
