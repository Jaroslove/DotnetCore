using System;
using System.Collections;
using System.Linq;

namespace MyWhere
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest iTest;
            
            Test test = new Test();
            
            iTest = Print((ITest)test);
        }

        static T Print<T>(in T test)
        {
            return test;
        }
    }

    interface ITest
    {
        void Print();
    }

    class Test : ITest
    {
        public void Print()
        {
            Console.WriteLine("test");
        }
    }
}