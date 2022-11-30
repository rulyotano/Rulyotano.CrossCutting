using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.DniTests
{
    public class DniMatchingTypes
    {
        private readonly Dni _dniDocument;

        public DniMatchingTypes()
        {
            _dniDocument = new Dni();
        }

        [Fact]
        public void Should_MatchDniTypes()
        {
            Assert.True(_dniDocument.MatchType(DocumentConstants.Types.Dni));
            Assert.True(_dniDocument.MatchType(DocumentConstants.Types.Dni.ToLower()));
        }

        [Fact]
        public void Should_MatchNifTypes()
        {
            Assert.True(_dniDocument.MatchType(DocumentConstants.Types.Nif));
            Assert.True(_dniDocument.MatchType(DocumentConstants.Types.Nif.ToLower()));
        }

        [Fact]
        public void ShouldNot_MatchOtherTypes()
        {
            Assert.False(_dniDocument.MatchType(DocumentConstants.Types.Nie));
            Assert.False(_dniDocument.MatchType(DocumentConstants.Types.Cif));
        }

        [Fact]
        public void ShouldNot_MatchNull()
        {
            Assert.False(_dniDocument.MatchType(null));
        }
    }
}
