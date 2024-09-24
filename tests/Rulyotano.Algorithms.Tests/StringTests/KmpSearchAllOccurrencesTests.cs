using System.Collections.Generic;
using Rulyotano.Algorithms.Strings;
using Xunit;

namespace Rulyotano.Algorithms.Tests.StringTests
{
    public class KmpSearchAllOccurrencesTests
    {
        private const int NotFound = -1;

        [Theory]
        [InlineData("", "abc")]
        [InlineData("abc", "")]
        [InlineData(null, "abc")]
        [InlineData("abc", null)]
        public void WhenNullOrEmptyShouldReturnEmpty(string text, string s)
        {
            var result = text.SearchAllOccurrences(s);
            Assert.Empty(result);
        }
        
        [Fact]
        public void WhenTextLengthIsLowerThanSearchLengthShouldReturnEmpty()
        {
            var result = "ab".SearchAllOccurrences("abc");
            Assert.Empty(result);
        }

        [Fact]
        public void WhenEqualStringsShouldReturnZero()
        {
            var result = "abc".SearchAllOccurrences("abc");
            Assert.Equal("0", ResultToString(result));
        }

        [Fact]
        public void WhenAreNotEqualsShouldReturnNotFound()
        {
            var result = "abd".SearchAllOccurrences("abc");
            Assert.Empty(result);
        }

        [Fact]
        public void WhenFirstOccurenceIsNotStartingOfStringShouldReturnCorrectIndex()
        {
            var result = "aaaabcdefg".SearchAllOccurrences("abc");
            Assert.Equal("3", ResultToString(result));
        }

        [Fact]
        public void WhenOccurenceIsAtTheEndOfTheStringShouldReturnCorrectIndex()
        {
            var result = "abeateabc".SearchAllOccurrences("abc");
            Assert.Equal("6", ResultToString(result));
        }

        [Fact]
        public void WhenThereIsNoOccurenceShouldReturnNotFound()
        {
            var result = "aaab".SearchAllOccurrences("abc");
            Assert.Empty(result);
        }

        [Fact]
        public void SameCharacterShouldReturnAllTheOccurrences()
        {
            var result = "aaaaa".SearchAllOccurrences("aaa");
            Assert.Equal("0,1,2", ResultToString(result));
        }

        [Fact]
        public void AnotherCase()
        {
            var result = "papapapapa".SearchAllOccurrences("papa");
            Assert.Equal("0,2,4,6", ResultToString(result));
        }

        private string ResultToString(IEnumerable<int> result)
        {
            return string.Join(",", result);
        }
    }
}