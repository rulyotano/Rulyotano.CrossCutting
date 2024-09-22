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
            var result = KmpLps.CalcualteLps("abcdefg");
            Assert.Equal("0,0,0,0,0,0,0", ResultToString(result));
        }

        private string ResultToString(int[] result)
        {
            return string.Join(",", result);
        }
    }
}
