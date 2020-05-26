using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = Enumerable.Range(1, 10).ToList();

            var comparator = new QuickSortKiller();

            for (int i = 0; i < source.Count() - 1; i++)
            {
                var isChange = comparator.Compare(source[0], source[i + 1]);

                if (isChange)
                {
                    var temp = source[i];
                    source[i] = source[i + 1];
                    source[i + 1] = temp;
                }
            }

            Print(SortSelect(source));
        }


        static IEnumerable<int> SortSelect(IEnumerable<int> source)
        {
            if (source != null)
            {
                var arSource = source.ToList();

                for (var i = 0; i < arSource.Count; i++)
                {
                    var j = i + 1;
                    var max = i;

                    while (j < arSource.Count && arSource[max] < arSource[j])
                    {
                        max = j;
                        j++;
                    }

                    var temp = arSource[max];
                    arSource[max] = arSource[i];
                    arSource[i] = temp;
                }

                return arSource;
            }

            return null;
        }

        static IEnumerable<int> SortBubble(IEnumerable<int> source)
        {
            if (source != null)
            {
                var arSource = source.ToList();

                for (var i = 0; i < arSource.Count - 2; i++)
                {
                    for (var j = arSource.Count - 1; j > i; j--)
                    {
                        if (arSource[i] < arSource[j])
                        {
                            int temp = arSource[i];
                            arSource[i] = arSource[j];
                            arSource[j] = temp;
                        }
                    }
                }

                return arSource;
            }

            return null;
        }

        static void Print<T>(IEnumerable<T> source)
        {
            if (source != null)
            {
                foreach (var item in source)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}