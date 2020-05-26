using System;

namespace StructData.Graph
{
    public class Graph
    {
        private const short MAX_VERTS = 20;
        private Vertex[] _vertices;
        private int[][] adjMat;
        private int nVerts;
        private StackX _stackX;

        public Graph()
        {
            _vertices = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS][];
            _stackX = new StackX();

            for (var j = 0; j < MAX_VERTS; j++)
            {
                adjMat[j] = new int[MAX_VERTS];
            }
        }

        public void AddVertex(char symbol)
        {
            _vertices[nVerts++] = new Vertex(symbol);
        }

        public void AddEdge(int start, int end)
        {
            adjMat[start][end] = 1;
            adjMat[end][start] = 1;
        }

        public void Print(int number)
        {
            Console.WriteLine(_vertices[number]);
        }

        public void TraverseInDeep()
        {
            _vertices[0].IsVisited = true;
            Print(0);
            _stackX.Push(0);

            while (!_stackX.IsEmpty())
            {
                var v = GetAdjUnivisitedVertex(_stackX.Peek());
                if (v == -1)
                {
                    _stackX.Pop();
                }
                else
                {
                    _vertices[v].IsVisited = true;
                    Print(v);
                    _stackX.Push(v);
                }
            }

            Nullify();
        }

        private int GetAdjUnivisitedVertex(int v)
        {
            for (var i = 0; i < nVerts; i++)
            {
                if (adjMat[v][i] == 1 && !_vertices[i].IsVisited)
                {
                    return i;
                }
            }

            return -1;
        }

        private void Nullify()
        {
            foreach (var vertex in _vertices)
            {
                if (vertex != null)
                {
                    vertex.IsVisited = false;
                }
            }
        }
    }
}