using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public interface IProcessor<T> where T : class, new()
    {
        bool Initialize();
        void Execute(ProcessItem<T> item);
        void Cleanup();
        void SetSuccessor(IProcessor<T> successor);
    }
}
