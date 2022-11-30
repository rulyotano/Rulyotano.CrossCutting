using System.Text.RegularExpressions;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public class Dni : PersonalDocument
    {
        private const string DniRegex = @"^\d{8}[" + DocumentConstants.ChecksumCharacters + "]$";
        private const int MinValid = 0;
        private const int MaxValid = 99999999;

        public override string Generate()
        {
            return Generate(MinValid, MaxValid);
        }

        public override bool IsValid(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            if (!IsOfType(cleanDocumentNumber)) return false;
            return CheckChecksumCharacter(cleanDocumentNumber);
        }

        public override bool MatchType(string documentType)
        {
            documentType = documentType?.ToUpperInvariant();
            return documentType == DocumentConstants.Types.Dni || documentType == DocumentConstants.Types.Nif;
        }

        public bool IsOfType(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            return new Regex(DniRegex).IsMatch(cleanDocumentNumber);
        }
    }
}
