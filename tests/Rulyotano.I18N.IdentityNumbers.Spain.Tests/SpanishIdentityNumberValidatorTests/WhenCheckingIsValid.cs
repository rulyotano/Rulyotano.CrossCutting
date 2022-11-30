using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.SpanishIdentityNumberValidatorTests
{
    public class WhenCheckingIsValid
    {
        private readonly SpanishIdentityNumberValidator _documentValidator;

        public WhenCheckingIsValid()
        {
            _documentValidator = new SpanishIdentityNumberValidator();
        }

        [Theory]
        [InlineData("A50923085")]
        [InlineData("C20063137")]
        [InlineData("P3342972A")]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        public void Should_MatchValidNumbersForAllTypes(string documentNumber)
        {
            Assert.True(_documentValidator.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("A50922085")]
        [InlineData("B01074253")]
        [InlineData("X7351541Y")]
        [InlineData("Z0230982E")]
        [InlineData("14333663Z")]
        [InlineData("49291465H")]
        public void Should_NotMatchInvalidNumbersForAllTypes(string documentNumber)
        {
            Assert.False(_documentValidator.IsValid(documentNumber));
        }
    }
}
