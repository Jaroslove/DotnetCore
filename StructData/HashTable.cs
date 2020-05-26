namespace StructData
{
    public class HashTable
    {
        private int _capacity;
        private Node[] _nodes;

        public HashTable() : this(10)
        {
        }

        public HashTable(int capacity)
        {
            _capacity = capacity;
            _nodes = new Node[_capacity];
        }

        public bool Insert(int value)
        {
            var hashCode = GetHashCode(value);

            var currentElement = _nodes[hashCode];

            if (currentElement == null)
            {
                _nodes[hashCode] = new Node(new Data {D = value});
            }
            else if (currentElement.NextNode == null)
            {
                currentElement.NextNode = new Node(new Data {D = value});
            }
            else
            {
                var elem = currentElement.NextNode;
                var nextElem = elem;

                while (nextElem != null)
                {
                    elem = nextElem;
                    nextElem = nextElem.NextNode;
                }

                elem.NextNode = new Node(new Data {D = value});
            }

            return true;
        }

        public Node Find(int value)
        {
            var hashCode = GetHashCode(value);

            var currentElement = _nodes[hashCode];

            while (currentElement != null)
            {
                if (currentElement.Data.D == value)
                {
                    return currentElement;
                }

                currentElement = currentElement.NextNode;
            }

            return null;
        }

        public bool Delete(int value)
        {
            var hashCode = GetHashCode(value);

            var currentElement = _nodes[hashCode];

            var preciousElement = currentElement;

            while (currentElement != null)
            {
                if (currentElement.Data.D == value)
                {
                    if (preciousElement == currentElement)
                    {
                        currentElement = null;
                        return true;
                    }

                    preciousElement.NextNode = currentElement.NextNode;

                    return true;
                }

                preciousElement = currentElement;
                currentElement = currentElement.NextNode;
            }

            return false;
        }

        private int GetHashCode(int value)
        {
            return value / _capacity;
        }
    }
}