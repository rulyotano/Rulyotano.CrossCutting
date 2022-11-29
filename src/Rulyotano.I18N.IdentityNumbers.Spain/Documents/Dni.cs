using System;
using System.Text.RegularExpressions;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public class Dni : ISpanishDocument
    {
        private const string ChecksumCharacters = "TRWAGMYFPDXBNJZSQVHLCKE";
        private const string DniRegex = @"^\d{8}[" + ChecksumCharacters + "]$";
        private const int MinValid = 0;
        private const int MaxValid = 99999999;

        public string Generate()
        {
            var rnd = new Random();
            var number = rnd.Next(MinValid, MaxValid);
            var checksum = number % ChecksumCharacters.Length;
            return $"{number.ToString("D8")}{ChecksumCharacters[checksum]}";
        }

        public bool IsOfType(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            return new Regex(DniRegex).IsMatch(cleanDocumentNumber);
        }

        public bool IsValid(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            if (!IsOfType(cleanDocumentNumber)) return false;
            var number = int.Parse(cleanDocumentNumber.Substring(0, 8));
            var checkSum = number % ChecksumCharacters.Length;
            return cleanDocumentNumber[cleanDocumentNumber.Length - 1] == ChecksumCharacters[checkSum];
        }
    }
}
