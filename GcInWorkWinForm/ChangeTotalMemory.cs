using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GcInWorkWinForm
{
    class ChangeTotalMemory
    {
        private readonly Action<long> action;

        public ChangeTotalMemory(Action<long> action)
        {
            this.action = action;
        }

        public void Change()
        {
            var total = GC.GetTotalMemory(true);

            action(total);
        }
    }
}
