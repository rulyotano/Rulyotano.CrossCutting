namespace Rulyotano.Algorithms.IdentityNumbers.Spain.Documents
{
    public interface ISpanishDocument
    {
        public bool IsOfType(string documentNumber);

        public bool IsValid(string documentNumber);

        public string Generate();
    }
}
