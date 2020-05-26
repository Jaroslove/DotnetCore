using System;

namespace GC
{
    public class Circle : IShape
    {
        public IShape GetShape()
        {
            Console.WriteLine("circle");
            return this;
        }
    }
}