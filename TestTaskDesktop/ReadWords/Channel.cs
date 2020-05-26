using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskDesktop.ReadWords
{
    class Channel<T>
    {
        private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private SemaphoreSlim _slim = new SemaphoreSlim(0);
        private bool isComplete;

        public void Write(T item)
        {
            _queue.Enqueue(item);
            _slim.Release();
        }

        public async Task<T> ReadAsync()
        {
            await _slim.WaitAsync();
            _queue.TryDequeue(out var result);
            return result;
        }

        public void Complete()
        {
            isComplete = true;
        }

        public bool IsComplete()
        {
            return isComplete && _queue.IsEmpty;
        }
    }
}
