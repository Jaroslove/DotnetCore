using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Thredings
{
    class Program
    {
        private static int counter;
        
        static async Task Main(string[] args)
        {
            var channel = new Channel<int>();

            var _ = Task.Run(async () =>
            {
                for (var i = 0; ; i++)
                {
                    await Task.Delay(1000);
                    channel.Write(i);
                }
            });

            while (true)
            {
                Console.WriteLine(await channel.Read());
            }
        }
    }

    class Channel<T>
    {
        private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private SemaphoreSlim _slim = new SemaphoreSlim(0);

        public void Write(T item)
        {
            _queue.Enqueue(item);
            _slim.Release();
        }

        public async Task<T> Read()
        {
            await _slim.WaitAsync();

            _queue.TryDequeue(out var result);

            return result;
        }
    }
}