using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures2
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{From} -> {To} ({Weight})";
        }
    }
}
