using System.Text.RegularExpressions;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public class Nie : PersonalDocument
    {
        private const string NieHeadingCharacters = "XYZ";
        private const string NieRegex = $"^[{NieHeadingCharacters}]" + @"\d{7}[" + DocumentConstants.ChecksumCharacters + "]$";
        private const int MinValid = 0;
        private const int MaxValid = 29999999;

        public override string Generate()
        {
            var generatedNumber = Generate(MinValid, MaxValid);

            return ReplaceHeadingDigit(generatedNumber);
        }

        public override bool IsValid(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            if (!IsOfType(cleanDocumentNumber)) return false;
            cleanDocumentNumber = ReplaceHeadingCharacter(cleanDocumentNumber);
            return CheckChecksumCharacter(cleanDocumentNumber);
        }

        public override bool MatchType(string documentType)
        {
            documentType = documentType?.ToUpperInvariant();
            return documentType == DocumentConstants.Types.Nie || documentType == DocumentConstants.Types.Nif;
        }

        public bool IsOfType(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            return new Regex(NieRegex).IsMatch(cleanDocumentNumber);
        }

        private static string ReplaceHeadingCharacter(string documentNumber)
        {
            var headingCharacter = documentNumber[0];
            var headingCharacterIndex = NieHeadingCharacters.IndexOf(headingCharacter);
            return $"{headingCharacterIndex}{documentNumber.Substring(1)}";
        }

        private static string ReplaceHeadingDigit(string documentNumber)
        {
            var headingDigit = int.Parse(documentNumber[0].ToString());
            return $"{NieHeadingCharacters[headingDigit]}{documentNumber.Substring(1)}";
        }
    }
}
