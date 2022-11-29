using System;

namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public abstract class PersonalDocument : ISpanishDocument
    {
        public abstract string Generate();
        public abstract bool IsOfType(string documentNumber);
        public abstract bool IsValid(string documentNumber);        
        protected static bool CheckChecksumCharacter(string cleanDocumentNumber)
        {
                var number = int.Parse(cleanDocumentNumber.Substring(0, 8));
                var checkSum = number % DocumentConstants.ChecksumCharacters.Length;
                return cleanDocumentNumber[cleanDocumentNumber.Length - 1] == DocumentConstants.ChecksumCharacters[checkSum];
        }
        protected static string Generate(int min, int max)
        {
            var rnd = new Random();
            var number = rnd.Next(min, max);
            var checksum = number % DocumentConstants.ChecksumCharacters.Length;
            return $"{number:D8}{DocumentConstants.ChecksumCharacters[checksum]}";
        }
    }
}
