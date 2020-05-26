using System;

namespace GC
{
    public class CTest : ITest
    {
        public int Value { get; set; }

        public void I()
        {
            Console.WriteLine("c test");
        }
    }
}