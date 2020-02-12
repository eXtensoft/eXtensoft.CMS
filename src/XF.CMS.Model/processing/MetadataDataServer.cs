using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public class MetadataDataServer : IDataServer<ProcessItem<Metadata>>
    {
        public int Max { get; set; }
        void IDataServer<ProcessItem<Metadata>>.Cleanup()
        {
            Console.WriteLine("MetadataDataServer Cleanup");
        }

        IEnumerator<ProcessItem<Metadata>> IEnumerable<ProcessItem<Metadata>>.GetEnumerator()
        {
            for (int i = 0; i < Max; i++)
            {
                var metadata = new Metadata() { Data = i.ToString() };
                yield return new ProcessItem<Metadata>()
                {
                    Model = new Metadata()
                    {
                        Data = i.ToString()
                    },
                    Index = i
                };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            throw new ArgumentNullException(); 
        }

        bool IDataServer<ProcessItem<Metadata>>.Initialize()
        {
            return true;
        }
    }
}
