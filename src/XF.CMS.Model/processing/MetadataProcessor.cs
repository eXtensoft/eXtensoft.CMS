using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conserver
{
    public class MetadataProcessor
    {
        public static void Execute()
        {
            List<IProcessor<Metadata>> processors = new List<IProcessor<Metadata>>();
            processors.Add(new DatabaseProcessor());
            processors.Add(new GroupProcessor());
            processors.Add(new FieldProcessor());
            processors.Add(new TailProcessor());

            IProcessEngine<Metadata> strategy = new MetadataProcessEngine<Metadata>()
            {
                DataSource = new MetadataDataServer() { Max = 1000  }, 
                Processors = processors
            };
            

            if (strategy.Initialize())
            {
                strategy.Execute();
                strategy.Cleanup();
            }
        }
    }
}
