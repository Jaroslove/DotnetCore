using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWhere
{
    public static class ExtLinq
    {
        public static IEnumerable<T> SuperWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate) 
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentException();
            }

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}