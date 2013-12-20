using System.Collections.Generic;
using System;

namespace Listless
{
    public static class Listless
    {
        public static void Swap<T>(this List<T> list, int a, int b)
        {
            if (a < 0 || a >= list.Count || b < 0 || b >= list.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }
}