using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.SpanishIdentityNumberValidatorTests
{
    public class WhenCheckingIsValidWithDocumentType
    {
        private readonly SpanishIdentityNumberValidator _documentValidator;

        public WhenCheckingIsValidWithDocumentType()
        {
            _documentValidator = new SpanishIdentityNumberValidator();
        }

        [Theory]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        public void WhenDni_Should_MatchDnis(string documentNumber)
        {
            Assert.True(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Dni));
        }

        [Theory]
        [InlineData("J40550634")]
        [InlineData("N0099964I")]
        [InlineData("P3342972A")]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        public void WhenDni_ShouldNot_MatchOtherTypes(string documentNumber)
        {
            Assert.False(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Dni));
        }

        [Theory]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        public void WhenNie_Should_MatchNies(string documentNumber)
        {
            Assert.True(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Nie));
        }

        [Theory]
        [InlineData("J40550634")]
        [InlineData("N0099964I")]
        [InlineData("P3342972A")]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        public void WhenNie_ShouldNot_MatchOtherTypes(string documentNumber)
        {
            Assert.False(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Nie));
        }

        [Theory]
        [InlineData("J40550634")]
        [InlineData("N0099964I")]
        [InlineData("P3342972A")]
        public void WhenCif_Should_MatchCifs(string documentNumber)
        {
            Assert.True(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Cif));
        }

        [Theory]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        public void WhenCif_ShouldNot_MatchOtherTypes(string documentNumber)
        {
            Assert.False(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Cif));
        }

        [Theory]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        public void WhenNif_Should_MatchDniAndNie(string documentNumber)
        {
            Assert.True(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Nif));
        }

        [Theory]
        [InlineData("J40550634")]
        [InlineData("N0099964I")]
        [InlineData("P3342972A")]
        public void WhenNif_ShouldNot_MatchCifs(string documentNumber)
        {
            Assert.False(_documentValidator.IsValid(documentNumber, DocumentConstants.Types.Nif));
        }

        [Theory]
        [InlineData("14333663V", DocumentConstants.Types.Dni)]
        [InlineData("Z2463117Y", DocumentConstants.Types.Nie)]
        [InlineData("N0099964I", DocumentConstants.Types.Cif)]
        [InlineData("14333663V", DocumentConstants.Types.Nif)]
        public void WhenLowecase_Should_MatchCorrectly(string documentNumber, string documentType)
        {
            Assert.True(_documentValidator.IsValid(documentNumber.ToLower(), documentType.ToLower()));
        }
    }
}
