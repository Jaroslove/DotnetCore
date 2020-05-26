using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTaskDesktop.Records
{
    class ShowRecord
    {
        private CancellationTokenSource _cts;
        Action<int> _action; 

        public ShowRecord(CancellationTokenSource cts, Action<int> action)
        {
            _cts = cts;
            _action = action;
        }

        public async void Show()
        {
            int i = 0;
            while (!_cts.Token.IsCancellationRequested)
            {
                await Task.Delay(1000);
                _action(i++);                
            }
        }

        public void Stop()
        {
            _cts.Cancel();
        }
    }
}
