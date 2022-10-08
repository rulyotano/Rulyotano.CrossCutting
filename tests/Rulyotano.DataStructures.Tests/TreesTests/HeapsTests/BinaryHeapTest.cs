using System;
using Rulyotano.DataStructures.Trees.Heaps;

namespace Rulyotano.DataStructures.Tests.TreesTests.HeapsTests
{
    public class BinaryHeapTest: BaseHeapTest
    {
        protected override IHeap<int> GetHeap(Func<int, int, int> compareFunc)
        {
            return new BinaryHeap<int>(compareFunc);
        }
    }
}
