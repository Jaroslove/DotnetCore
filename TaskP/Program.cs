using System;
using System.Threading;
using System.Threading.Tasks;
using TaskP.OwnAwaiter;

namespace TaskP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(new MyClass().ToString());
            new MyClass().Display();
//            var result = await new Awaitable<int>();
//
//            Console.WriteLine(result);
        }
    }

    class MyClass
    {
        public override string ToString()
        {
            Console.WriteLine("hi");
            return base.ToString();
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }
    }
}