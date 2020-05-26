using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTaskDesktop.ReadWords
{
    class Counter
    {
        public Counter(IProgress<int> progress, CancellationToken cancellationToken)
        {
            this.progress = progress;
            this.cancellationToken = cancellationToken;
        }

        private readonly IProgress<int> progress;
        private readonly CancellationToken cancellationToken;

        public async Task<double> CountAsync(string text, int total, int current)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                return await Task.Run(() => {
                    var count = text.Split(' ').Count();
                    
                    var prog = (current + 1) / (float)total * 100;

                    progress.Report((int)prog);

                    return count;
                });
            }
            return 0;
        }
    }
}
