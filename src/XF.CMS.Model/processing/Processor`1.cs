using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public abstract class Processor<T> : IProcessor<T> where T : class, new()
    {
        public int Index { get; set; }
        protected IProcessor<T> Successor { get; set; }

        bool IProcessor<T>.Initialize()
        {
            bool b = Initialize();
            return (b && Successor != null) ? Successor.Initialize() : b;
        }

        void IProcessor<T>.Execute(ProcessItem<T> item)
        {

            Execute(item);
            if (Successor != null && !item.IsCancelled)
            {
                Successor.Execute(item);
            }
        }

        void IProcessor<T>.Cleanup()
        {
            Cleanup();
            if (Successor != null)
            {
                Successor.Cleanup();
            }
        }

        void IProcessor<T>.SetSuccessor(IProcessor<T> successor)
        {
            Successor = successor;
        }

        protected virtual bool Initialize()
        {
            return true;
        }

        protected virtual void Cleanup()
        {

        }

        protected abstract void Execute(ProcessItem<T> item);



    }
}
