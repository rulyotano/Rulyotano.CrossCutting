using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.CifTests
{
    public class CifMatchingTypes
    {
        private readonly Cif _cifDocument;

        public CifMatchingTypes()
        {
            _cifDocument = new Cif();
        }

        [Fact]
        public void Should_MatchCifTypes()
        {
            Assert.True(_cifDocument.MatchType(DocumentConstants.Types.Cif));
            Assert.True(_cifDocument.MatchType(DocumentConstants.Types.Cif.ToLower()));
        }

        [Fact]
        public void ShouldNot_MatchOtherTypes()
        {
            Assert.False(_cifDocument.MatchType(DocumentConstants.Types.Nie));
            Assert.False(_cifDocument.MatchType(DocumentConstants.Types.Dni));
            Assert.False(_cifDocument.MatchType(DocumentConstants.Types.Nif));
        }

        [Fact]
        public void ShouldNot_MatchNull()
        {
            Assert.False(_cifDocument.MatchType(null));
        }
    }
}
