using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.DniTests
{
    public class DniWhenCheckingIsValid
    {
        private readonly Dni _dniDocument;

        public DniWhenCheckingIsValid()
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
        [InlineData("60080190G")]
        public void Should_ValidateCorrectDocuments(string documentNumber)
        {
            Assert.True(_dniDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("14333663Z")]
        [InlineData("49291465H")]
        [InlineData("44554905G")]
        [InlineData("62905200T")]
        [InlineData("47094434K")]
        [InlineData("33939726A")]
        public void Should_NotValidate_When_ChecksumIsWrong(string documentNumber)
        {
            Assert.False(_dniDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("14333663I")]
        [InlineData("49291465O")]
        [InlineData("47094434U")]
        public void Should_NotValidate_When_NotSupportedChecksumCharacter(string documentNumber)
        {
            Assert.False(_dniDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("143333663V")]
        [InlineData("4932591465G")]
        [InlineData("554905H")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_dniDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("62905200q")]
        [InlineData("47094434w")]
        [InlineData("33939726y")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_dniDocument.IsValid(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_dniDocument.IsValid(null));
        }
    }
}
