using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures2
{
    class Vertex
    {
        public int Number { get; set; }
        public override string ToString()
        {
            return Number.ToString();
        }

        public Vertex(int number)
        {
            if(number <= 0)
            {
                throw new Exception("Номер вершины должен быть больше 0");
            }
            Number = number;
        }
    }
}
