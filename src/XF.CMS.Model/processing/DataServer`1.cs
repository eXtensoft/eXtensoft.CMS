using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver.code
{
    public abstract class DataServer<T> : IDataServer<ProcessItem<T>> where T : class, new()
    {
        void IDataServer<ProcessItem<T>>.Cleanup()
        {
            throw new NotImplementedException();
        }

        IEnumerator<ProcessItem<T>> IEnumerable<ProcessItem<T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool IDataServer<ProcessItem<T>>.Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
