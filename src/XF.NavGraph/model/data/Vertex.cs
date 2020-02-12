using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.Json.Serialization;

namespace XF.Core.Data
{
    public class Vertex : Item
    {
        public Graph Graph { get; set; }
        [JsonIgnore]
        public List<Edge> Inbound
        {
            get { return Graph.Edges.Where(x => x.To == this).ToList(); }
        }
        [JsonIgnore]
        public List<Edge> Outbound
        {
            get { return Graph.Edges.Where(x => x.From == this).ToList(); }
        }
    }
}
