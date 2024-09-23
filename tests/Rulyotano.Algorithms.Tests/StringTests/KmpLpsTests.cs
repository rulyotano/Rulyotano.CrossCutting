using Rulyotano.Algorithms.Strings;
using Xunit;

namespace Rulyotano.Algorithms.Tests.StringTests
{
    public class KmpLpsTests
    {
        [Fact]
        public void WhenLengthIsZeroShouldReturnEmptyArray()
        {
            var result = KmpLps.CalcualteLps(string.Empty);
            Assert.Empty(result);
        }

        [Fact]
        public void WhenNullShouldReturnEmptyArray()
        {
            var result = KmpLps.CalcualteLps(null);
            Assert.Empty(result);
        }

        [Fact]
        public void WhenLengthIsOneShouldReturnSingleZeroArray()
        {
            var result = KmpLps.CalcualteLps("A");
            Assert.Equal("0", ResultToString(result));
        }

        [Fact]
        public void WhenTwoEqualLettersShouldReturnArray01()
        {
            var result = KmpLps.CalcualteLps("AA");
            Assert.Equal("0,1", ResultToString(result));
        }

        [Fact]
        public void WhenAllItemsAreDifferentShouldReturnAllZeros()
        {
            var result = KmpLps.CalcualteLps("abc");
            Assert.Equal("0,0,0", ResultToString(result));
        }

        [Theory]
        [InlineData("abczababcd", "0,0,0,0,1,2,1,2,3,0")]
        [InlineData("aaabaaac", "0,1,2,0,1,2,3,0")]
        [InlineData("abccba", "0,0,0,0,0,1")]
        public void ShouldBuildCorrectLongestPrefixSuffixForAllThePositions(string testCase, string expectedResult)
        {
            var result = KmpLps.CalcualteLps(testCase);
            Assert.Equal(expectedResult, ResultToString(result));
        }

        private string ResultToString(int[] result)
        {
            return string.Join(",", result);
        }
    }
}
