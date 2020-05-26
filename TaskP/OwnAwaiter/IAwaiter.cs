using System.Runtime.CompilerServices;

namespace TaskP.OwnAwaiter
{
    public interface IAwaiter<out T> : INotifyCompletion
    {
        bool IsCompleted { get; }

        T GetResult();
    }
}