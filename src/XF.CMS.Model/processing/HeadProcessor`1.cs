using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public sealed class HeadProcessor<T> : Processor<T> where T : class, new()
    {
        protected override void Execute(ProcessItem<T> item)
        {

        }
    }

}
