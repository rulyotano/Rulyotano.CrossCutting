using Rulyotano.Algorithms.Strings;
using Xunit;

namespace Rulyotano.Algorithms.Tests.StringTests
{
    public class KmpSearchFirstOccurrenceTests
    {
        private const int NotFound = -1;

        [Theory]
        [InlineData("", "abc")]
        [InlineData("abc", "")]
        [InlineData(null, "abc")]
        [InlineData("abc", null)]
        public void WhenNullOrEmptyShouldReturnNotFound(string text, string s)
        {
            var result = text.SearchFirstOccurrence(s);
            Assert.Equal(NotFound, result);
        }
        
        [Fact]
        public void WhenTextLengthIsLowerThanSearchLengthShouldReturnNotFound()
        {
            var result = "ab".SearchFirstOccurrence("abc");
            Assert.Equal(NotFound, result);
        }

        [Fact]
        public void WhenEqualStringsShouldReturnZero()
        {
            var result = "abc".SearchFirstOccurrence("abc");
            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenAreNotEqualsShouldReturnNotFound()
        {
            var result = "abd".SearchFirstOccurrence("abc");
            Assert.Equal(NotFound, result);
        }

        [Fact]
        public void WhenFirstOccurenceIsNotStartingOfStringShouldReturnCorrectIndex()
        {
            var result = "aaaabcdefg".SearchFirstOccurrence("abc");
            Assert.Equal(3, result);
        }

        [Fact]
        public void WhenOccurenceIsAtTheEndOfTheStringShouldReturnCorrectIndex()
        {
            var result = "abeateabc".SearchFirstOccurrence("abc");
            Assert.Equal(6, result);
        }

        [Fact]
        public void WhenThereIsNoOccurenceShouldReturnNotFound()
        {
            var result = "aaab".SearchFirstOccurrence("abc");
            Assert.Equal(-1, result);
        }

        [Fact]
        public void SameCharacterShouldReturnFirstOccurence()
        {
            var result = "aaaaa".SearchFirstOccurrence("aaa");
            Assert.Equal(0, result);
        }

        [Fact]
        public void AnotherCase()
        {
            var result = "abceabcfabceabck".SearchFirstOccurrence("abceabck");
            Assert.Equal(8, result);
        }
    }
}