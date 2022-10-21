using System;
using System.Collections.Generic;

namespace Rulyotano.Algorithms.SortedArrays
{
    public static partial class SortedArray
    {
        /// <summary>
        /// Find the insert index where insert an element to a collection in order to keep it ordered
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">List where to search in</param>
        /// <param name="compareFunction">Compare function. Receives comparing item. Return 0 if current equals, > 0 if current is greater and < 0 if current is lower</param>
        /// <returns></returns>
        public static int FindInsertIndex<T>(IList<T> collection, Func<T, int> compareFunction)
        {
            if (collection.Count == 0) return 0;
            var (foundIndex, bestIndex) = BinarySearch(collection, compareFunction, 0, collection.Count - 1);
            if (foundIndex == NotFound && compareFunction(collection[bestIndex]) < 0)
            {
                bestIndex++;
            }

            return bestIndex;
        }
    }
}
