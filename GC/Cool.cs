namespace GC
{
    class  Cool
    {
        static Cool()
        {
            var s = "sfds";
            Cool.TestS = "s";
        }
        
        public static string TestS = "tesss";
        
        public const string TEST = "test";
        
        private readonly string Test;

        public Cool(string test)
        {
            Test = test;
        }
    }
}