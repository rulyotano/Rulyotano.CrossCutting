using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.NieTests
{
    public class NieMatchingTypes
    {
        private readonly Nie _nieDocument;

        public NieMatchingTypes()
        {
            _nieDocument = new Nie();
        }

        [Fact]
        public void Should_MatchNieTypes()
        {
            Assert.True(_nieDocument.MatchType(DocumentConstants.Types.Nie));
            Assert.True(_nieDocument.MatchType(DocumentConstants.Types.Nie.ToLower()));
        }

        [Fact]
        public void Should_MatchNifTypes()
        {
            Assert.True(_nieDocument.MatchType(DocumentConstants.Types.Nif));
            Assert.True(_nieDocument.MatchType(DocumentConstants.Types.Nif.ToLower()));
        }

        [Fact]
        public void ShouldNot_MatchOtherTypes()
        {
            Assert.False(_nieDocument.MatchType(DocumentConstants.Types.Dni));
            Assert.False(_nieDocument.MatchType(DocumentConstants.Types.Cif));
        }

        [Fact]
        public void ShouldNot_MatchNull()
        {
            Assert.False(_nieDocument.MatchType(null));
        }
    }
}
