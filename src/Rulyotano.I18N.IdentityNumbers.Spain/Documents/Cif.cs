using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public class Cif : ISpanishDocument
    {
        private const string ChecksumCharacters = "JABCDEFGHI";
        private const string TypeOfOrganizationCharacters = "ABCDEFGHJKLMNPQRSUVW";
        private const string OrganizationTypeGroupName = "OrganizationType";
        private const string NumberGroupName = "Number";
        private const string ChecksumGroupName = "Checksum";
        private const string CifRegex = $"^(?<" + OrganizationTypeGroupName + $">[{TypeOfOrganizationCharacters}])" + "(?<" + NumberGroupName + @">\d{7})(?<" + ChecksumGroupName + @">[\d" + ChecksumCharacters + "])$";
        private const int MinValid = 0;
        private const int MaxValid = 10000000;

        public string Generate()
        {
            var rnd = new Random();
            var organization = TypeOfOrganizationCharacters[rnd.Next(0, TypeOfOrganizationCharacters.Length)].ToString();
            var number = rnd.Next(MinValid, MaxValid).ToString("D7");
            var checksum = GetChecksum(organization, number);
            return $"{organization}{number}{checksum}";
        }

        public bool IsOfType(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            return new Regex(CifRegex).IsMatch(cleanDocumentNumber);
        }

        public bool IsValid(string documentNumber)
        {
            var cleanDocumentNumber = documentNumber?.ToUpperInvariant() ?? string.Empty;
            if (!IsOfType(cleanDocumentNumber)) return false;
            return CheckChecksumCharacter(cleanDocumentNumber);
        }

        private bool CheckChecksumCharacter(string cleanDocumentNumber)
        {
            var regexMatch = new Regex(CifRegex).Match(cleanDocumentNumber);
            var organization = regexMatch.Groups[OrganizationTypeGroupName].Value;
            var number = regexMatch.Groups[NumberGroupName].Value;
            var checksum = regexMatch.Groups[ChecksumGroupName].Value;
            return checksum == GetChecksum(organization, number);
        }

        private string GetChecksum(string organization, string number)
        {
            var evenSum = GetEvenSum(number);
            var oddSum = GetOddSum(number);
            var partialSum = evenSum + oddSum;
            var unitDigit = partialSum % 10;
            var checksum = (10 - unitDigit) % ChecksumCharacters.Length;
            if (OrganizationHasChecksumLetter(organization)) return ChecksumCharacters[checksum].ToString();
            return checksum.ToString();
        }

        private int GetOddSum(string number)
        {
            return number.Where((character, index) => index % 2 == 0).Sum(GetOddCharacterSum);
        }

        private static int GetOddCharacterSum(char character)
        {
            var charValue = 2 * (character - '0');
            var sumOfDigits = (charValue / 10) % 10 + charValue % 10;
            return sumOfDigits;
        }

        private int GetEvenSum(string number)
        {
            return number.Where((character, index) => index % 2 == 1).Sum(character => character - '0');
        }

        private bool OrganizationHasChecksumLetter(string organization)
        {
            var organizationChar = organization[0];
            return 'N' <= organizationChar && organizationChar <= 'S' || organizationChar >= 'W';
        }
    }
}
