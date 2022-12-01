using Rulyotano.I18N.IdentityNumbers.Spain.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rulyotano.I18N.IdentityNumbers.Spain
{
    public class SpanishIdentityNumberValidator : IIdentityNumberValidator
    {
        private const string CountryRegex = @"^(ESP|ES|[A-Z]{2}-ES)$";
        private readonly IEnumerable<ISpanishDocument> _documents;

        public SpanishIdentityNumberValidator()
        {
            _documents = new ISpanishDocument[] { new Dni(), new Nie(), new Cif() };
        }

        public bool IsCountry(string countryCode)
        {
            return new Regex(CountryRegex).IsMatch(countryCode?.ToUpperInvariant() ?? string.Empty);
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
