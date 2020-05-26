using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ListRandom listRandom = new ListRandom();
            var next = new ListNode {Data = "2"};
            var random = new ListNode {Data = "random"};
            var head = new ListNode {Data = "1", Next = next, Random = random};
            listRandom.Head = head;
            next.Previous = head;
            listRandom.Tail = next;

            var serObj = SerializeDeserializer.Serialize(listRandom);

            var desOfj = SerializeDeserializer.Deserialize<ListRandom>(serObj);

            Console.WriteLine(desOfj);
        }
    }

    
    
    public static class SerializeDeserializer
    {
        public static byte[] Serialize<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, obj);

                return stream.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] serializedObj)
        {
            T obj = default(T);
            using (MemoryStream memStream = new MemoryStream(serializedObj))
            {
                BinaryFormatter binSerializer = new BinaryFormatter();
                obj = (T) binSerializer.Deserialize(memStream);
            }

            return obj;
        }
    }

    [Serializable]
    class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random;
        public string Data;
    }

    [Serializable]
    class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
        }

        public void Deserialize(Stream s)
        {
        }
    }
}