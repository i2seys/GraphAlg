using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures2
{
    class Program
    {
        /*
        Алгоритм: Напишите программу, на входе которой вводятся две вершины графа. 
        Программа должна распечатывать все (простые) пути, ведущие от 
        одной вершины к другой.

        Способ представления  графа:Список дуг
        ////////////////////////////////////////////////////////////////////////////////
        Реализовать функции - (1 балл из 5)
        Реализовать задание (заданный алгоритм) (1 балл из 5) с использованием методов АТД 
        «Граф» (1 балл из 5)
        Оформление отчета не менее чем с двумя контрольными примерами, для каждого примера 
        приводится рисунок (допускается скан рисунка «от руки» или изображение построенное c помощью 
        графического или специализированного редактора) графа (1 балл из 5).
        Защита работы (1 балл из 5)

         */
        static void Main(string[] args)
        {
            MyGraph graph1 = new MyGraph();
            InitMyGraph1(ref graph1);

            MyGraph graph2 = new MyGraph();
            InitMyGraph2(ref graph2);

            Console.WriteLine("ГРАФ 1");
            graph1.PrintListOfArcs();
            Console.WriteLine("ГРАФ 2");
            graph2.PrintListOfArcs();

            Console.WriteLine("ГРАФ 1 | ИЗ 9 В 2");
            graph1.FindPaths(9, 2);
            Console.WriteLine("ГРАФ 2 | ИЗ 1 В 10");
            graph2.FindPaths(1, 10);
        }
        private static void InitMyGraph1(ref MyGraph graph)
        {
            graph = new MyGraph();
            //ОТКУДА|КУДА|ВЕС 
           
            Vertex v1 = new Vertex(1);
            Vertex v2 = new Vertex(2);
            Vertex v3 = new Vertex(3);
            Vertex v4 = new Vertex(4);
            Vertex v5 = new Vertex(5);
            Vertex v6 = new Vertex(6);
            Vertex v7 = new Vertex(7);
            Vertex v8 = new Vertex(8);
            Vertex v9 = new Vertex(9);
            Vertex v10 = new Vertex(10);
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);
            graph.AddVertex(v9);
            graph.AddVertex(v10);

            Edge e1 = new Edge(v1, v2, 3);
            Edge e2 = new Edge(v1, v3, 1);
            Edge e3 = new Edge(v2, v1, 3);
            Edge e4 = new Edge(v2, v6, 2); 
            Edge e5 = new Edge(v2, v9, 7);
            Edge e6 = new Edge(v3, v1, 1);
            Edge e7 = new Edge(v3, v4, 3);
            Edge e8 = new Edge(v3, v7, 5);
            Edge e9 = new Edge(v4, v2, 1);
            Edge e10 = new Edge(v4, v5, 12); 
            Edge e11 = new Edge(v4, v7, 5);
            Edge e12 = new Edge(v4, v9, 7);
            Edge e13 = new Edge(v4, v10, 7);
            Edge e14 = new Edge(v5, v9, 6);
            Edge e15 = new Edge(v6, v8, 15);
            Edge e16 = new Edge(v6, v9, 2);
            Edge e17 = new Edge(v7, v4, 5);
            Edge e18 = new Edge(v7, v8, 7);
            Edge e19 = new Edge(v7, v10, 3);
            Edge e20 = new Edge(v8, v5, 11);
            Edge e21 = new Edge(v8, v6, 15);
            Edge e22 = new Edge(v9, v4, 7);
            Edge e23 = new Edge(v9, v5, 6);
            Edge e24 = new Edge(v9, v6, 2);
            Edge e25 = new Edge(v10, v4, 7);
            Edge e26 = new Edge(v10, v5, 5);
            Edge e27 = new Edge(v10, v7, 3);

            graph.AddEdge(e1);
            graph.AddEdge(e2);
            graph.AddEdge(e3);
            graph.AddEdge(e4);
            graph.AddEdge(e5);
            graph.AddEdge(e6);
            graph.AddEdge(e7);
            graph.AddEdge(e8);
            graph.AddEdge(e9);
            graph.AddEdge(e10);
            graph.AddEdge(e11);
            graph.AddEdge(e12);
            graph.AddEdge(e13);
            graph.AddEdge(e14);
            graph.AddEdge(e15);
            graph.AddEdge(e16);
            graph.AddEdge(e17);
            graph.AddEdge(e18);
            graph.AddEdge(e19);
            graph.AddEdge(e20);
            graph.AddEdge(e21);
            graph.AddEdge(e22);
            graph.AddEdge(e23);
            graph.AddEdge(e24);
            graph.AddEdge(e25);
            graph.AddEdge(e26);
            graph.AddEdge(e27);
        }
        private static void InitMyGraph2(ref MyGraph graph)
        {
            graph = new MyGraph();
            //ОТКУДА|КУДА|ВЕС 
            Vertex v1 = new Vertex(1);
            Vertex v2 = new Vertex(2);
            Vertex v3 = new Vertex(3);
            Vertex v4 = new Vertex(4);
            Vertex v5 = new Vertex(5);
            Vertex v6 = new Vertex(6);
            Vertex v7 = new Vertex(7);
            Vertex v8 = new Vertex(8);
            Vertex v9 = new Vertex(9);
            Vertex v10 = new Vertex(10);
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);
            graph.AddVertex(v9);
            graph.AddVertex(v10);

            Edge e1 = new Edge(v1, v2, 1);
            Edge e2 = new Edge(v1, v4, 7);
            Edge e3 = new Edge(v2, v3, 3);
            Edge e4 = new Edge(v2, v5, 2);
            Edge e5 = new Edge(v3, v2, 3);
            Edge e6 = new Edge(v3, v5, 5);
            Edge e7 = new Edge(v3, v6, 1);
            Edge e8 = new Edge(v4, v5, 1);
            Edge e9 = new Edge(v4, v7, 3);
            Edge e10 = new Edge(v5, v1, 5);
            Edge e11 = new Edge(v5, v3, 5);
            Edge e12 = new Edge(v5, v4, 1);
            Edge e13 = new Edge(v5, v6, 3);
            Edge e14 = new Edge(v5, v8, 2);
            Edge e15 = new Edge(v5, v9, 3);
            Edge e16 = new Edge(v6, v3, 1);
            Edge e17 = new Edge(v6, v5, 3);
            Edge e18 = new Edge(v7, v4, 3);
            Edge e19 = new Edge(v7, v10, 7);
            Edge e20 = new Edge(v8, v4, 3);
            Edge e21 = new Edge(v8, v5, 2);
            Edge e22 = new Edge(v8, v7, 2);
            Edge e23 = new Edge(v9, v5, 3);
            Edge e24 = new Edge(v9, v8, 6);
            Edge e25 = new Edge(v10, v7, 7);
            Edge e26 = new Edge(v10, v9, 6);

            graph.AddEdge(e1);
            graph.AddEdge(e2);
            graph.AddEdge(e3);
            graph.AddEdge(e4);
            graph.AddEdge(e5);
            graph.AddEdge(e6);
            graph.AddEdge(e7);
            graph.AddEdge(e8);
            graph.AddEdge(e9);
            graph.AddEdge(e10);
            graph.AddEdge(e11);
            graph.AddEdge(e12);
            graph.AddEdge(e13);
            graph.AddEdge(e14);
            graph.AddEdge(e15);
            graph.AddEdge(e16);
            graph.AddEdge(e17);
            graph.AddEdge(e18);
            graph.AddEdge(e19);
            graph.AddEdge(e20);
            graph.AddEdge(e21);
            graph.AddEdge(e22);
            graph.AddEdge(e23);
            graph.AddEdge(e24);
            graph.AddEdge(e25);
            graph.AddEdge(e26);
        }
        
    }
}
