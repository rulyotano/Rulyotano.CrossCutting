using System;
using Rulyotano.DataStructures.Trees.Heaps;
using Xunit;

namespace Rulyotano.DataStructures.Tests.TreesTests.HeapsTests
{
    public abstract class BaseHeapTest
    {
        protected abstract IHeap<int> GetHeap(Func<int, int, int> compareFunc);
        protected static readonly Func<int, int, int> MinFunc = (x, y) => x - y;
        protected static readonly Func<int, int, int> MaxFunc = (x, y) => y - x;

        [Fact]
        public void When_MinHeapOrderFunction_Should_ReturnItemsStartingByTheLowerOne()
        {
            var items = new int[3, 1, 6];
            var heap = GetHeap(MinFunc);
            foreach (var item in items)
            {
                heap.Add(item);
            }
            Assert.Equal(3, heap.Count);
            var result1 = heap.Extract();
            var result2 = heap.Extract();
            var result3 = heap.Extract();
            Assert.Equal(1, result1);
            Assert.Equal(3, result2);
            Assert.Equal(6, result3);
            Assert.Equal(0, heap.Count);
        }

        [Fact]
        public void When_MaxHeapOrderFunction_Should_ReturnItemsStartingByTheGreaterOne()
        {
            var items = new int[3, 1, 6];
            var heap = GetHeap(MaxFunc);
            foreach (var item in items)
            {
                heap.Add(item);
            }
            Assert.Equal(3, heap.Count);
            var result1 = heap.Extract();
            var result2 = heap.Extract();
            var result3 = heap.Extract();
            Assert.Equal(6, result1);
            Assert.Equal(3, result2);
            Assert.Equal(1, result3);
            Assert.Equal(0, heap.Count);
        }
    }
}
