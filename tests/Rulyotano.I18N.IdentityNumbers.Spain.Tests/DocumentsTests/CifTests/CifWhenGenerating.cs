using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using System.Collections.Generic;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.CifTests
{
    public class CifWhenGenerating
    {
        private readonly Cif _cifDocument;

        public CifWhenGenerating()
        {
            _cifDocument = new Cif();
        }

        [Fact]
        public void WhenGenerating_Should_BeBeValid()
        {
            var result = _cifDocument.Generate();
            Assert.True(_cifDocument.IsValid(result));
        }

        [Fact]
        public void WhenGenerating_Should_CreateDifferentNumbers()
        {
            var alreadyGenerated = new HashSet<string>();
            for (int i = 0; i < 100; i++)
            {
                var newDni = _cifDocument.Generate();
                if (!alreadyGenerated.Contains(newDni)) alreadyGenerated.Add(newDni);
            }
            Assert.True(alreadyGenerated.Count > 1);
        }
    }
}
