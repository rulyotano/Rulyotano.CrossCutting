using Rulyotano.Algorithms.IdentityNumbers.Spain.Documents;
using System.Collections.Generic;
using Xunit;

namespace Rulyotano.Algorithms.IdentityNumbers.Spain.Tests.DocumentsTests.DniTests
{
    public class DniWhenGenerating
    {
        private readonly Dni _dniDocument;

        public DniWhenGenerating()
        {
            _dniDocument = new Dni();
        }

        [Fact]
        public void WhenGenerating_Should_BeBeValid()
        {
            var result = _dniDocument.Generate();
            Assert.True(_dniDocument.IsValid(result));
        }

        [Fact]
        public void WhenGenerating_Should_CreateDifferentNumbers()
        {
            var alreadyGenerated = new HashSet<string>();
            for (int i = 0; i < 100; i++)
            {
                var newDni = _dniDocument.Generate();
                if (!alreadyGenerated.Contains(newDni)) alreadyGenerated.Add(newDni);
            }
            Assert.True(alreadyGenerated.Count > 1);
        }
    }
}
