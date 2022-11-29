using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.NieTests
{
    public class NieWhenCheckingIsValid
    {
        private readonly Nie _nieDocument;

        public NieWhenCheckingIsValid()
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
            Assert.True(_nieDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("X7351541Y")]
        [InlineData("Z0230982E")]
        [InlineData("Y2418665S")]
        [InlineData("X1010875E")]
        [InlineData("Y6193831M")]
        [InlineData("Y6647020K")]
        public void Should_NotValidate_When_ChecksumIsWrong(string documentNumber)
        {
            Assert.False(_nieDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("X4333663I")]
        [InlineData("Y9291465O")]
        [InlineData("Z7094434U")]
        public void Should_NotValidate_When_NotSupportedChecksumCharacter(string documentNumber)
        {
            Assert.False(_nieDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("X43333663V")]
        [InlineData("Y932591465G")]
        [InlineData("Z54905H")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_nieDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("z2463117y")]
        [InlineData("z5410057w")]
        [InlineData("x7211541y")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_nieDocument.IsValid(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_nieDocument.IsValid(null));
        }
    }
}
