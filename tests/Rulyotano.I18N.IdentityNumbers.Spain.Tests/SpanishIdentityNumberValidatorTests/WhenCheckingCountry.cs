using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.SpanishIdentityNumberValidatorTests
{
    public class WhenCheckingCountry
    {
        private readonly SpanishIdentityNumberValidator _documentValidator;

        public WhenCheckingCountry()
        {
            _documentValidator = new SpanishIdentityNumberValidator();
        }

        [Theory]
        [InlineData("ES")]
        [InlineData("Es")]
        [InlineData("es")]
        [InlineData("ESP")]
        [InlineData("Esp")]
        [InlineData("esp")]
        [InlineData("ES-ES")]
        [InlineData("es-ES")]
        [InlineData("es-es")]
        [InlineData("en-es")]
        [InlineData("EN-es")]
        public void Should_MatchValidCountryCodes(string countryCode)
        {
            Assert.True(_documentValidator.IsCountry(countryCode));
        }

        [Theory]
        [InlineData("AR")]
        [InlineData("ar")]
        [InlineData("IT")]
        [InlineData("SPAIN")]
        [InlineData("ESPAÑA")]
        [InlineData("SP")]
        [InlineData("ES-US")]
        [InlineData("es-AR")]
        [InlineData("es-ar")]
        [InlineData("es-it")]
        [InlineData("es-co")]
        [InlineData(null)]
        public void Should_NotMatchNotValidCountryCodes(string countryCode)
        {
            Assert.False(_documentValidator.IsCountry(countryCode));
        }
    }
}
