using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.NieTests
{
    public class NieWhenCheckingTypeOfDocument
    {
        private readonly Nie _nieDocument;

        public NieWhenCheckingTypeOfDocument()
        {
            _nieDocument = new Nie();
        }

        [Theory]
        [InlineData("Z2463117Y")]
        [InlineData("Z5410057W")]
        [InlineData("X7211541Y")]
        [InlineData("Z4230982E")]
        [InlineData("Y2478665S")]
        [InlineData("X1010895E")]
        [InlineData("Y6193891M")]
        [InlineData("Y6647030K")]
        public void Should_ValidateCorrectDocuments(string documentNumber)
        {
            Assert.True(_nieDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("X4333663I")]
        [InlineData("Z9291465O")]
        [InlineData("Y7094434U")]
        public void Should_NotValidate_When_NumberEndsInNotSupportedCharacter(string documentNumber)
        {
            Assert.False(_nieDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("Z24631137Y")]
        [InlineData("Z541005337W")]
        [InlineData("X721154Y")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_nieDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("z2463117y")]
        [InlineData("z5410057w")]
        [InlineData("x7211541y")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_nieDocument.IsOfType(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_nieDocument.IsOfType(null));
        }
    }
}
