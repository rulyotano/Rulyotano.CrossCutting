using Rulyotano.Algorithms.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.Algorithms.IdentityNumbers.Spain.Tests.DocumentsTests.DniTests
{
    public class DniWhenCheckingTypeOfDocument
    {
        private readonly Dni _dniDocument;

        public DniWhenCheckingTypeOfDocument()
        {
            _dniDocument = new Dni();
        }

        [Theory]
        [InlineData("14333663V")]
        [InlineData("49291465G")]
        [InlineData("44554905H")]
        [InlineData("62905200Q")]
        [InlineData("47094434W")]
        [InlineData("33939726Y")]
        public void Should_ValidateCorrectDocuments(string documentNumber)
        {
            Assert.True(_dniDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("14333663I")]
        [InlineData("49291465O")]
        [InlineData("47094434U")]
        public void Should_NotValidate_When_NumberEndsInNotSupportedCharacter(string documentNumber)
        {
            Assert.False(_dniDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("143333663V")]
        [InlineData("4932591465G")]
        [InlineData("554905H")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_dniDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("62905200q")]
        [InlineData("47094434w")]
        [InlineData("33939726y")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_dniDocument.IsOfType(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_dniDocument.IsOfType(null));
        }
    }
}
