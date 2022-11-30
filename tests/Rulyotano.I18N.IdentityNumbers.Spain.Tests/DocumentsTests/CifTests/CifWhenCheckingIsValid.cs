using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.CifTests
{
    public class CifWhenCheckingIsValid
    {
        private readonly Cif _cifDocument;

        public CifWhenCheckingIsValid()
        {
            _cifDocument = new Cif();
        }

        [Theory]
        [InlineData("A50923085")]
        [InlineData("B01073253")]
        [InlineData("C20063137")]
        [InlineData("D16712341")]
        [InlineData("E50130947")]
        [InlineData("F48581664")]
        [InlineData("G26510321")]
        [InlineData("H75698704")]
        [InlineData("J40550634")]
        [InlineData("N0099964I")]
        [InlineData("P3342972A")]
        [InlineData("Q0065830B")]
        [InlineData("R0048766J")]
        [InlineData("S1046245E")]
        [InlineData("U13426770")]
        [InlineData("V22356950")]
        [InlineData("W2315753J")]
        public void Should_ValidateCorrectDocuments(string documentNumber)
        {
            Assert.True(_cifDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("A50922085")]
        [InlineData("B01074253")]
        [InlineData("C20061137")]
        [InlineData("D16712541")]
        [InlineData("N0199964I")]
        [InlineData("P3442972A")]
        public void Should_NotValidate_When_ChecksumIsWrong(string documentNumber)
        {
            Assert.False(_cifDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("A5092308Z")]
        [InlineData("B0107325Q")]
        [InlineData("C2006313K")]
        public void Should_NotValidate_When_NotSupportedChecksumCharacter(string documentNumber)
        {
            Assert.False(_cifDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("A5092208225")]
        [InlineData("B010334474253")]
        [InlineData("C201137")]
        public void Should_NotValidate_When_NumberLengthIsNotCorrect(string documentNumber)
        {
            Assert.False(_cifDocument.IsValid(documentNumber));
        }

        [Theory]
        [InlineData("a50923085")]
        [InlineData("b01073253")]
        [InlineData("w2315753j")]
        public void Should_ValidateWhenLowercase(string documentNumber)
        {
            Assert.True(_cifDocument.IsValid(documentNumber));
        }

        [Fact]
        public void Should_NotValidate_Null()
        {
            Assert.False(_cifDocument.IsValid(null));
        }
    }
}
