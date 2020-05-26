namespace TaskP
{
    public class FinalClass
    {
        private string _x; 
        
        public FinalClass(string x)
        {
            _x = x;
        }
        
        ~ FinalClass()
        {
            _x = null;
        }
    }
}