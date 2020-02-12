using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Data
{
    public class Graph: Item
    {
        public string Id { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {

        
        }
        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
            foreach (var vertex in vertices)
            {
                vertex.Graph = this;
            }
        }
    }
}
