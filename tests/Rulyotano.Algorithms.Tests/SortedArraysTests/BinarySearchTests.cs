using System;
using System.Collections.Generic;
using Rulyotano.Algorithms.SortedArrays;
using Xunit;

namespace Rulyotano.Algorithms.Tests.SortedArraysTests
{
    public class BinarySearchTests
    {
        [Fact]
        public void WhenEmpty_Should_ReturnNotFound()
        {
            var collection = new int[0];
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(0));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Fact]
        public void When_OneElementAndMatch_Should_ReturnCorrectIndex()
        {
            const int searchValue = 3;
            var collection = new int[] { searchValue };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(0, result);
        }

        [Fact]
        public void When_OneElementAndNotMatchGreater_Should_ReturnNotFound()
        {
            const int searchValue = 3;
            var collection = new int[] { 2 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Fact]
        public void When_OneElementAndNotMatchLower_Should_ReturnNotFound()
        {
            const int searchValue = 3;
            var collection = new int[] { 5 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(11)]
        public void When_TwoElementsAndNoMatch_Should_ReturnNotFound(int searchValue)
        {
            var collection = new int[] { 6, 9 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 1)]
        public void When_TwoElementsAndMatch_Should_ReturnCorrectIndex(int searchValue, int expectedIndex)
        {
            var collection = new int[] { 3, 5 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(11)]
        [InlineData(15)]
        public void When_ThreeElementsAndNoMatch_Should_ReturnNotFound(int searchValue)
        {
            var collection = new int[] { 6, 9, 13 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 1)]
        [InlineData(8, 2)]
        public void When_ThreeElementsAndMatch_Should_ReturnCorrectIndex(int searchValue, int expectedIndex)
        {
            var collection = new int[] { 3, 5, 8 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(61, 8)]
        [InlineData(8, 2)]
        [InlineData(55, 7)]
        public void When_SeveralOddElementsAndMatch_Should_ReturnCorrectIndex(int searchValue, int expectedIndex)
        {
            var collection = new int[] { 3, 5, 8, 11, 12, 17, 20, 55, 61 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(2)]
        [InlineData(62)]
        [InlineData(13)]
        public void When_SeveralEvenElementsAndMatch_Should_ReturnCorrectIndex(int searchValue)
        {
            var collection = new int[] { 3, 5, 8, 11, 12, 17, 20, 55, 61 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Theory]
        [InlineData(3, 1)]
        public void When_ThreeElementsAndRepeated_Should_ReturnMiddleIndex(int searchValue, int expectedIndex)
        {
            var collection = new int[] { 3, 3, 3 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(2)]
        public void When_ThreeElementsAndRepeatedAndNoMatch_Should_ReturnNotFound(int searchValue)
        {
            var collection = new int[] { 3, 3, 3 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(SortedArray.NotFound, result);
        }

        [Theory]
        [InlineData(3, 1)]
        public void When_FourElementsAndRepeated_Should_ReturnMiddleIndex(int searchValue, int expectedIndex)
        {
            var collection = new int[] { 3, 3, 3, 3 };
            var result = SortedArray.BinarySearch(collection, GetCompareFunction(searchValue));

            Assert.Equal(expectedIndex, result);
        }

        private Func<int, int> GetCompareFunction(int searchValue) => (int current) => current - searchValue;
    }
}
