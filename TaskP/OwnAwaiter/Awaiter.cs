using System;

namespace TaskP.OwnAwaiter
{
    public sealed class Awaiter<T> : IAwaiter<T>
    {
        public void OnCompleted(Action continuation)
        {
            Console.WriteLine("on completed");
            continuation();
        }

        public bool IsCompleted
        {
            get
            {
                Console.WriteLine("get");
                return false;
            }
        }

        public T GetResult()
        {
            Console.WriteLine("result");
            
            return default(T);
        }
    }
}