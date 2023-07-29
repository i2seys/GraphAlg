using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures2
{
    class MyGraph
    {
        public List<Vertex> Vertexes { get; set; } = new List<Vertex>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public void PrintListOfArcs()
        {
            Console.WriteLine("Вывод списка дуг графа:");
            foreach (Edge edge in Edges)
            {
                Console.WriteLine(edge.ToString());
            }
        }
        /// <summary>
        /// Добавить узел
        /// </summary>
        public void AddVertex(Vertex v)
        {
            Vertexes.Add(v);
        }
        /// <summary>
        /// Добавить дугу
        /// </summary>
        /// <param name="e"></param>
        public void AddEdge(Edge e)
        {
            Edges.Add(e);
        }
        /// <summary>
        /// Удалить узел
        /// </summary>

        public bool DelVertex(int vertex)
        {
            //1)получить Vertex с номером number 
            //2)если такой vertex есть, то удалить его из списка Vertexes и удалить упоминания из списка Edges и вернуть true
            //3)если нет, то вернуть false

            int currentVertexesCount = 0;
            int vertexInd = 0;
            for(int i = 0; i < Vertexes.Count; i++)
            {
                if(Vertexes[i].Number == vertex) 
                {
                    vertexInd = i;
                    currentVertexesCount++;
                }
            }
            if(currentVertexesCount == 1)
            {
                Vertexes.RemoveAt(vertexInd);
                //то удаляем её из списка вершин и удаляем из списка дуг
                for (int j = 0; j < Edges.Count; j++)
                {
                    if(Edges[j].From.Number == vertex || Edges[j].To.Number == vertex)
                    {
                        Edges.RemoveAt(j);
                        j--;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Удалить дугу
        /// </summary>
        public bool DelEdge(int vertex1, int vertex2)
        {
            bool isDeleted = false;
            for(int i = 0; i < Edges.Count; i++)
            {
                if((Edges[i].From.Number == vertex1 && Edges[i].To.Number == vertex2) ||
                        (Edges[i].From.Number == vertex2 && Edges[i].To.Number == vertex1))
                {
                    Edges.RemoveAt(i);
                    i--;
                    isDeleted = true;
                }
            }
            return isDeleted;
        }
        /// <summary>
        /// vertex1 = from, vertex2 = to (Изменить вес дуги)
        /// </summary>
        public bool EditEdge(int vertex1, int vertex2, int weight)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].From.Number == vertex1 && Edges[i].To.Number == vertex2)
                {
                    Edges[i].Weight = weight;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// изменить метку (маркировку) вершины
        /// </summary>
        public bool EditVertex(int vertex, int toChange)
        {
            //в каких случаях не можем менять?
            //1)если vertex==toChange
            if (vertex == toChange)
            {
                return false;
            }

            //2)если такая уже есть
            for (int i = 0; i < Vertexes.Count; i++)
            {
                if(Vertexes[i].Number == toChange)
                {
                    return false;
                }
            }

            //3)если vertex не существует
            bool vertexExist = false;
            int vertexInd = 0;
            for(int i = 0; i < Vertexes.Count; i++)
            {
                if(Vertexes[i].Number == vertex)
                {
                    vertexExist = true;
                    vertexInd = i;
                    break;
                }
            }
            if(vertexExist == false)
            {
                return false;
            }


            //заменить везде vertex на toChange
            Vertexes[vertexInd].Number = toChange;

            for(int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].From.Number == vertex)
                {
                    Edges[i].From.Number = toChange;
                }
                else if(Edges[i].To.Number == vertex)
                {
                    Edges[i].To.Number = toChange;
                }
            }
            
            return true;

            //попробовать заменить в тупую в листе Vertexes вес, заменится ли он во всех значениях Edges?
        }

        /// <summary>
        ///  Возвращает индекс первой вершины, смежной с вершиной vertex. Если вершина v не 
        ///  имеет смежных вершин, то возвращается "нулевая" вершина.
        /// </summary>
        /// <returns></returns>
        public int First(int vertex)
        {
            int adjacent = int.MaxValue;
            bool vertexFind = false;
            for (int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].From.Number == vertex && Edges[i].To.Number < adjacent)
                {
                    adjacent = Edges[i].To.Number;
                    vertexFind = true;
                }
            }
            return vertexFind == false ? 0 : adjacent;
        }
        /// <summary>
        /// Возвращает индекс вершины, смежной с вершиной vertex, следующий за индексом ind. 
        /// Если ind — это индекс последней вершины, смежной с вершиной vertex, то возвращается нулевая вершина.
        /// </summary>
        public int Next(int vertex, int index)
        {
            bool vertexFind = false;
            int adjacent = int.MaxValue;
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].From.Number == vertex && Edges[i].To.Number > index && Edges[i].To.Number < adjacent)
                {
                    adjacent = Edges[i].To.Number;
                    vertexFind = true;
                }
            }
            return vertexFind == false ? 0 : adjacent;
        }
        /// <summary>
        /// возвращает вершину с индексом index из множества вершин, смежных с vertex.
        /// </summary>
        public int GetVertex(int vertex, int index)
        {
            if(index < 0)
            {
                return 0;
            }
            SortedSet<int> connectedVertexes = new SortedSet<int>();
            for(int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].From.Number == vertex)
                {
                    connectedVertexes.Add(Edges[i].To.Number);
                }
            }
            if(index >= connectedVertexes.Count)
            {
                return 0;
            }
            else
            {
                return connectedVertexes.ElementAt(index);
            }
        }
        private List<int> GetNeighbors(int vertex)
        {
            List<int> res = new List<int>();
            for(int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].From.Number == vertex)
                {
                    res.Add(Edges[i].To.Number);
                }
            }
            return res;
        }
        public void FindPaths(int from, int to)
        {
            List<int> startList = new List<int>(Vertexes.Count);
            startList.Add(from);
            bool[] startVisited = new bool[Vertexes.Count];
            startVisited[from-1] = true;
            Dfs(from, to, startList, startVisited);
        }
        private void Dfs(int currentVertex, int endVertex, List<int> paths, bool[] visited)//поиск в глубину
        {
            if(currentVertex == endVertex)
            {
                int pathLength = 0;
                for(int i = 0; i < paths.Count; i++)
                {
                    if(i != paths.Count - 1)
                    {
                        pathLength += EdgeLength(paths[i], paths[i + 1]);
                    }
                    Console.Write(paths[i] + " ");
                }
                Console.WriteLine($" | Path length = {pathLength}");
                return;
            }
            List<int> neighbors = GetNeighbors(currentVertex);
            foreach (int neighbor in neighbors)
            {
                if (visited[neighbor - 1] == false)
                {
                    paths.Add(neighbor);
                    visited[neighbor - 1] = true;
                    Dfs(neighbor, endVertex, paths, visited);
                    paths.RemoveAt(paths.Count - 1);
                    visited[neighbor - 1] = false;
                }
            }
        }
        private int EdgeLength(int from, int to)
        {
            for(int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].From.Number == from && Edges[i].To.Number == to)
                {
                    return Edges[i].Weight;
                }
            }
            throw new Exception("Edge Length error");
        }
    }
}
