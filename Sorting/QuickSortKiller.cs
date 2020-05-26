using System.Collections.Generic;

namespace Sorting
{
    public class QuickSortKiller
    {
        private Dictionary<int, int> keys = new Dictionary<int, int>();

        private int candidate = 0;

        public bool Compare(int x, int y)
        {
            if (!keys.ContainsKey(x) && !keys.ContainsKey(y))
            {
                if (x == candidate)
                {
                    keys[x] = keys.Count;
                }
                else
                {
                    keys[y] = keys.Count;
                }
            }

            if (!keys.ContainsKey(x))
            {
                candidate = x;
                return true;
            }

            if (!keys.ContainsKey(y))
            {
                candidate = y;
                return false;
            }

            return x - y < 0;
        }
    }
}