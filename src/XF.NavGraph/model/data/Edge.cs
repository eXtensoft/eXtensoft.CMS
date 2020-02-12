using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XF.Core.Data
{
    public class Edge : Item
    {
        public Direction Vector { get; set; }

        [JsonIgnore]
        public Vertex From { get; set; }
        [JsonIgnore]
        public Vertex To { get; set; }
    }
}
