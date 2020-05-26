namespace StructData.Graph
{
    public class Vertex
    {
        public readonly char Label;
        public bool IsVisited;

        public Vertex(char label)
        {
            Label = label;
        }

        public override string ToString()
        {
            return Label.ToString();
        }
    }
}