using System;

namespace GC
{
    public struct STest : ITest
    {
        public int Value { get; set; }

        public void I()
        {
            Console.WriteLine("s test");
        }
    }
}