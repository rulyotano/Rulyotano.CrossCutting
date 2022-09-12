using System;
using System.Collections.Generic;
using Rulyotano.Algorithms.SortedArrays;
using Xunit;

namespace Rulyotano.Algorithms.Tests.SortedArraysTests
{
    public class FindInsertIndexTests
    {
        [Fact]
        public void WhenEmpty_Should_RetrunFirstIndex()
        {
            var collection = new int[0];
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(0));

            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenOneItemAndLower_Should_ReturnFirstIndex()
        {
            var collection = new int[] { 1 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(-1));

            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenOneItemAndEqual_Should_ReturnFirstIndex()
        {
            var collection = new int[] { 1 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(1));

            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenOneItemAndGreater_Should_ReturnArrayLength()
        {
            var collection = new int[] { 1 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(2));

            Assert.Equal(collection.Length, result);
        }

        [Fact]
        public void WhenTwoItemsAndLower_Should_ReturnFirstIndex()
        {
            var collection = new int[] { 3, 7 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(0));

            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenTwoItemsAndInTheMiddle_Should_ReturnSecondItemIndex()
        {
            var collection = new int[] { 3, 7 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(5));

            Assert.Equal(1, result);
        }

        [Fact]
        public void WhenTwoItemsAndGreater_Should_ReturnCollectionLength()
        {
            var collection = new int[] { 3, 7 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(9));

            Assert.Equal(collection.Length, result);
        }

        [Fact]
        public void WhenTwoItemsAndEqualToFirst_Should_ReturnFirstIndex()
        {
            var collection = new int[] { 3, 7 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(3));

            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenTwoItemsAndEqualToSecond_Should_ReturnLastIndex()
        {
            var collection = new int[] { 3, 7 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(7));

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(7, 1)]
        [InlineData(9, 2)]
        [InlineData(10, 2)]
        [InlineData(11, 3)]
        [InlineData(200, 3)]
        public void WhenThreeSeveralCases_Should_ReturnExpectedIndex(int testValue, int expectedIndex)
        {
            var collection = new int[] { 3, 7, 10 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(testValue));

            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, 2)]
        [InlineData(28, 8)]
        [InlineData(31, 9)]
        [InlineData(32, 10)]
        [InlineData(20, 5)]
        public void WhenSeveralItemsSeveralCases_Should_ReturnExpectedIndex(int testValue, int expectedIndex)
        {
            var collection = new int[] { 3, 7, 10, 10, 19, 21, 25, 25, 30, 31 };
            var result = SortedArray.FindInsertIndex(collection, GetCompareFunction(testValue));

            Assert.Equal(expectedIndex, result);
        }

        private Func<int, int> GetCompareFunction(int searchValue) => (int current) => current - searchValue;
    }
}
