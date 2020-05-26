using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDesktop.Helpers
{
    class ExtTask
    {
        public async Task One()
        {
            await Task.Delay(2000);
            throw new NotImplementedException();
        }

        public async Task Two()
        {
            await Task.Delay(2000);
            throw new NotImplementedException();
        }

        public async Task<int> Three()
        {
            await Task.Delay(2000);
            throw new NotImplementedException();
        }
    }
}
