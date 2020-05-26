namespace TaskP.OwnAwaiter
{
    public interface IAwaitable<out T>
    {
        IAwaiter<T> GetAwaiter();
    }
}