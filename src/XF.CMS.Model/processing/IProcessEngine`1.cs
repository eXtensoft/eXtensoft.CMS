using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public interface IProcessEngine<T> where T : class, new()
    {
        bool Initialize();
        void Execute();
        void Cleanup();
    }
}
