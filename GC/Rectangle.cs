using System;

namespace GC
{
    public class Rectangle : IShape
    {
        public IShape GetShape()
        {
            Console.WriteLine("Rectangle");
            return this;
        }
    }
}