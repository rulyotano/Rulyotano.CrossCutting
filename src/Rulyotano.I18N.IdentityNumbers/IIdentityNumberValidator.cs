namespace Rulyotano.I18N.IdentityNumbers;

public interface IIdentityNumberValidator
{
    bool IsValid(string identityNumber);
    bool IsValid(string identityNumber, string documentType);
}
