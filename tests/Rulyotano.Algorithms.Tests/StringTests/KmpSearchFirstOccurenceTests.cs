using Rulyotano.Algorithms.Strings;
using Xunit;

namespace Rulyotano.Algorithms.Tests.StringTests
{
    public class KmpSearchTests
    {
        private const int NotFound = -1;

        [Theory]
        [InlineData("", "abc")]
        [InlineData("abc", "")]
        [InlineData(null, "abc")]
        [InlineData("abc", null)]
        public void WhenNullOrEmptyShouldReturnNotFound(string text, string s)
        {
            var result = text.SearchFirstOccurence(s);
            Assert.Equal(NotFound, result);
        }
        
        [Fact]
        public void WhenTextLengthIsLowerThanSearchLengthShouldReturnNotFound()
        {
            var result = "ab".SearchFirstOccurence("abc");
            Assert.Equal(NotFound, result);
        }

        [Fact]
        public void WhenEqualStringsShouldReturnZero()
        {
            var result = "abc".SearchFirstOccurence("abc");
            Assert.Equal(0, result);
        }

        [Fact]
        public void WhenAreNotEqualsShouldReturnNotFound()
        {
            var result = "abd".SearchFirstOccurence("abc");
            Assert.Equal(NotFound, result);
        }

        [Fact]
        public void WhenFirstOccurenceIsNotStartingOfStringShouldReturnCorrectIndex()
        {
            var result = "aaaabcdefg".SearchFirstOccurence("abc");
            Assert.Equal(3, result);
        }

        [Fact]
        public void WhenCorrenceIsAtTheEndOfTheStringShouldReturnCorrectIndex()
        {
            var result = "abeateabc".SearchFirstOccurence("abc");
            Assert.Equal(6, result);
        }

        [Fact]
        public void WhenThereIsNoOccurenceShouldReturnNotFound()
        {
            var result = "aaab".SearchFirstOccurence("abc");
            Assert.Equal(-1, result);
        }

        [Fact]
        public void SameCharacterShouldReturnFirstOccurence()
        {
            var result = "aaaaa".SearchFirstOccurence("aaa");
            Assert.Equal(0, result);
        }

        [Fact]
        public void AnotherCase()
        {
            var result = "abceabcfabceabck".SearchFirstOccurence("abceabck");
            Assert.Equal(8, result);
        }
    }
}