using System;

namespace StructData
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph.Graph();
            
            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            
            graph.AddEdge(0,1);
            graph.AddEdge(0,3);
            graph.AddEdge(1,3);
            graph.AddEdge(0,2);
            
            graph.TraverseInDeep();
        }
    }
}