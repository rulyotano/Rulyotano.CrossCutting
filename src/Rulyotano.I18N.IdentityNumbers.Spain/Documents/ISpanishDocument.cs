namespace Rulyotano.I18N.IdentityNumbers.Spain.Documents
{
    public interface ISpanishDocument
    {
        public bool IsValid(string documentNumber);

        public string Generate();

        public bool MatchType(string documentType);
    }
}
