namespace TaskP.OwnAwaiter
{
    public class Awaitable<T> : IAwaitable<T>
    {
        public IAwaiter<T> GetAwaiter()
        {
            return new Awaiter<T>();
        }
    }
}