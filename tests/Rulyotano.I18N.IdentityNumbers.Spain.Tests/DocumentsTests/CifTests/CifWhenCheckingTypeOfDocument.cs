using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.CifTests
{
    public class CifWhenCheckingTypeOfDocument
    {
        private readonly Cif _cifDocument;

        public CifWhenCheckingTypeOfDocument()
        {
            _cifDocument = new Cif();
        }

        [Theory]
        [InlineData("N4932226F")]
        [InlineData("G00617787")]
        [InlineData("C01287572")]
        [InlineData("Q1865289A")]
        [InlineData("P5203822A")]
        [InlineData("S7346204F")]
        public void Should_ValidateCorrectDocuments(string documentNumber)
        {
            Assert.True(_cifDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("N4932226K")]
        [InlineData("G0061778L")]
        [InlineData("C0128757Z")]
        public void Should_NotValidate_When_NumberEndsInNotSupportedCharacter(string documentNumber)
        {
            Assert.False(_cifDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("14333663V")]
        [InlineData("Z2463117Y")]
        [InlineData("Y6647030K")]
        [InlineData("60080190G")]
        public void Should_NotValidate_When_OtherTypeOfDocuments(string documentNumber)
        {
            Assert.False(_cifDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("N49322263F")]
        [InlineData("G0061577827")]
        [InlineData("C012875")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_cifDocument.IsOfType(documentNumber));
        }

        [Theory]
        [InlineData("n4932226f")]
        [InlineData("g00617787")]
        [InlineData("c01287572")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_cifDocument.IsOfType(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_cifDocument.IsOfType(null));
        }
    }
}
