using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using System.Collections.Generic;
using System.Linq;

namespace Rulyotano.I18N.IdentityNumbers.Spain
{
    public class SpanishIdentityNumberValidator : IIdentityNumberValidator
    {
        private readonly IEnumerable<ISpanishDocument> _documents;

        public SpanishIdentityNumberValidator()
        {
            _documents = new ISpanishDocument[] { new Dni(), new Nie(), new Cif() };
        }

        public bool IsValid(string identityNumber)
        {
            return _documents.Any(document => document.IsValid(identityNumber));
        }

        public bool IsValid(string identityNumber, string documentType)
        {
            return _documents.Any(document => document.MatchType(documentType) && document.IsValid(identityNumber));
        }
    }
}
