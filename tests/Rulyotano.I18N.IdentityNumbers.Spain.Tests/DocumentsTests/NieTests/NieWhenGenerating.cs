using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using System.Collections.Generic;
using Xunit;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Tests.DocumentsTests.NieTests
{
    public class NieWhenGenerating
    {
        private readonly Nie _nieDocument;

        public NieWhenGenerating()
        {
            _nieDocument = new Nie();
        }

        [Fact]
        public void WhenGenerating_Should_BeBeValid()
        {
            var result = _nieDocument.Generate();
            Assert.True(_nieDocument.IsValid(result));
        }

        [Fact]
        public void WhenGenerating_Should_CreateDifferentNumbers()
        {
            var alreadyGenerated = new HashSet<string>();
            for (int i = 0; i < 100; i++)
            {
                var newDni = _nieDocument.Generate();
                if (!alreadyGenerated.Contains(newDni)) alreadyGenerated.Add(newDni);
            }
            Assert.True(alreadyGenerated.Count > 1);
        }
    }
}
