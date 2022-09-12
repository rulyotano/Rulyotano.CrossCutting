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
            if (start > end) return (NotFound, NotFound);
            if (start == end)
            {
                var whenEqualsComapreResult = compareFunction(collection[start]);
                if (whenEqualsComapreResult == 0) return (start, start);
                var currentIsGreater = whenEqualsComapreResult > 0;
                return currentIsGreater ? (NotFound, start) : (NotFound, start + 1);
            }
            if (end - start == 1)
            {
                var compareStartResult = compareFunction(collection[start]);
                if (compareStartResult == 0) return (start, start);
                var compareEndResult = compareFunction(collection[end]);
                if (compareEndResult == 0) return (end, end);
                var isLowerThanStart = compareStartResult > 0;
                if (isLowerThanStart) return (NotFound, start);
                var isGreaterThanEnd = compareEndResult < 0;
                if (isGreaterThanEnd) return (NotFound, end + 1);
                return (NotFound, start + 1);                
            }

            var middIndex = (start + end) / 2;
            var middElement = collection[middIndex];
            var compareResult = compareFunction(middElement);
            if (compareResult == 0)
            {
                return (middIndex, middIndex);
            }

            if (compareResult > 0)
            {
                return BinarySearch(collection, compareFunction, start, middIndex);
            }

            return BinarySearch(collection, compareFunction, middIndex, end);
        }
    }
}
