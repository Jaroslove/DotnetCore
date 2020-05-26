namespace StructData
{
    public class Node
    {
        public Data Data { get; set; }
        public Node NextNode { get; set; }
        
        public Node(Data data)
        {
            Data = data;
        }
    }
}