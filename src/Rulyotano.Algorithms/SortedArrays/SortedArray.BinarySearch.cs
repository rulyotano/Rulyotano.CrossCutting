using System;
using System.Collections.Generic;

namespace Rulyotano.Algorithms.SortedArrays
{
    public static partial class SortedArray
    {
        public const int NotFound = -1;

        /// <summary>
        /// Do a binary search in a sorted list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">List where to search in</param>
        /// <param name="compareFunction">Compare function. Receives the comparing item. Return 0 if current equals, > 0 if current is greater and < 0 if current is lower</param>
        /// <returns></returns>
        public static int BinarySearch<T>(IList<T> collection, Func<T, int> compareFunction)
        {
            var (foundIndex, _) = BinarySearch(collection, compareFunction, 0, collection.Count - 1);
            return foundIndex;
        }

        private static (int foundIndex, int bestIndex) BinarySearch<T>(IList<T> collection, Func<T, int> compareFunction, int start, int end)
        {
            var middIndex = NotFound;
            while (start <= end)
            {
                middIndex = (start + end) / 2;
                var compareResult = compareFunction(collection[middIndex]);
                if (compareResult == 0) return (middIndex, middIndex);
                if (compareResult > 0)
                {
                    end = middIndex - 1;
                } else
                {
                    start = middIndex + 1;
                }
            }

            return (NotFound, middIndex);
        }
    }
}
