using System.Collections.Generic;
using System;
using UnityEngine;

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

        public static T Random<T>(this List<T> list)
        {
            return list.Random(1)[0];
        }

        public static List<T> Random<T>(this List<T> list, int count)
        {
            if (count > list.Count)
            {
                throw new IndexOutOfRangeException();
            }

            List<int> chosenIndexes = new List<int>();
            List<T> chosenItems = new List<T>();

            for (int i = 0; i < count; i++)
            {
                int chosenIndex = UnityEngine.Random.Range(0, list.Count);;

                while (chosenIndexes.Contains(chosenIndex))
                {
                    chosenIndex = UnityEngine.Random.Range(0, list.Count);
                } 

                chosenIndexes.Add(chosenIndex);
                chosenItems.Add(list[chosenIndex]);
            }

            return chosenItems;
        }

        public static List<T> RandomWithReplacement<T>(this List<T> list, int count)
        {
            List<T> chosenItems = new List<T>();
            chosenItems.Add(list.Random());
            return chosenItems;
        }
    }
}