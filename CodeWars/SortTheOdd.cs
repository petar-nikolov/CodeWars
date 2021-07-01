using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    public class SortTheOdd
    {
        public static int[] SortArray(int[] array)
        {
            // 0  1 2  3  4 5   6  7 8  9  10
            //15,79,14,80

            var orderedList = new List<int>();
            var arrayList = array.ToList();
            var evenNumbers = arrayList.Where(i => i % 2 == 0).ToDictionary(i => i, i => arrayList.IndexOf(i));
            var oddNumbers = arrayList.Where(i => i % 2 != 0).OrderBy(x => x).ToArray();
            var indexToStart = 0;
            var oddNumberIndex = 0;

            if (!evenNumbers.Any())
            {
                orderedList.AddRange(arrayList.OrderBy(x => x));
            }

            foreach (var evenNumberPosition in evenNumbers.Values)
            {
                var endToIterate = evenNumberPosition;
                if (evenNumberPosition == 0)
                {
                    indexToStart = evenNumberPosition + 1;
                    orderedList.Add(arrayList[evenNumberPosition]);
                    if (evenNumbers.Values.Count() == 1)
                    {
                        endToIterate = array.Length;
                    }
                }

                if (evenNumberPosition <= array.Length - 1 && evenNumberPosition.Equals(array.Length - 1))
                {
                    orderedList.Add(arrayList[evenNumberPosition]);
                    endToIterate = array.Length - 1;
                }

                for (int i = indexToStart; i < endToIterate; i++)
                {
                    orderedList.Add(oddNumbers[oddNumberIndex]);
                    oddNumberIndex++;
                }

                if (evenNumberPosition != evenNumbers.Values.Last())
                {
                    orderedList.Add(arrayList[evenNumberPosition]);
                }

                indexToStart = evenNumberPosition + 1;
            }

            return orderedList.ToArray();
        }

        public static int[] SortArray2(int[] array)
        {
            var orderedList = new List<int>();
            var arrayList = array.ToList();
            //var evenNumbers = arrayList.Where(i => i % 2 == 0).ToList();
            var evenNumbers = new List<int>();

            var oddNumbers = arrayList.Where(i => i % 2 != 0).OrderBy(x => x).ToArray();
            var indexToStart = 0;
            var oddNumberIndex = 0;

            if (!evenNumbers.Any())
            {
                orderedList.AddRange(array.OrderBy(x => x));
            }
            else if (!oddNumbers.Any())
            {
                return array;
            }

            var intervalsToSort = new List<int>();
            var evenNumIndexes = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenNumbers.Add(array[i]);
                    evenNumIndexes.Add(i);
                }
            }

            for (int i = 0; i < evenNumIndexes.Count - 1; i++)
            {
                var currIndex = evenNumIndexes[i];
                var nextIndex = evenNumIndexes[i + 1];
                if (currIndex != nextIndex - 1)
                {
                    intervalsToSort.Add(currIndex);
                }
            }

            return array;
        }

        public static int[] SortArray3(int[] array)
        {
            var orderedList = new List<int>();
            var arrayList = array.ToList();
            var oddNumbers = arrayList.Where(i => i % 2 != 0).OrderBy(x => x).ToArray();
            var oddIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    orderedList.Add(array[i]);
                }
                else
                {
                    orderedList.Add(oddNumbers[oddIndex]);
                    oddIndex++;
                }
            }

            return orderedList.ToArray();
        }
    }
}