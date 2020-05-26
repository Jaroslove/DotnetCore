namespace StructData.Graph
{
    public class StackX
    {
        private const int MAX_SIZE = 20;

        private readonly int[] _array;

        private int _top;

        public StackX()
        {
            _array = new int[MAX_SIZE];
            _top = -1;
        }

        public void Push(int element)
        {
            _array[++_top] = element;
        }

        public int Pop()
        {
            return _array[_top--];
        }

        public int Peek()
        {
            return _array[_top];
        }

        public bool IsEmpty()
        {
            return _top == -1;
        }
    }
}