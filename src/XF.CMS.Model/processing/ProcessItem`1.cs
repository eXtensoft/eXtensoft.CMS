using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public class ProcessItem<T> where T : class, new()
    {
        public int Index { get; set; }
        public bool IsCancelled { get; set; }
        public T Model { get; set; }
    }
}
