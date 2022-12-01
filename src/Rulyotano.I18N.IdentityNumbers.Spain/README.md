<a href="https://www.nuget.org/packages/Rulyotano.I18N.IdentityNumbers.Spain"><img src="https://img.shields.io/nuget/v/Rulyotano.I18N.IdentityNumbers.Spain?logo=nuget"/></a>
<img src="https://img.shields.io/github/last-commit/rulyotano/Rulyotano.CrossCutting?logo=github"/>

# Rulyotano.I18N.IdentityNumbers.Spain
Identity numbers for Spain
- DNI
- NIE
- CIF
- NIF

## We can:
- Check if are valid
- Check if are valid by type
- Generate them

## Install

```
NuGet\Install-Package Rulyotano.I18N.IdentityNumbers.Spain
```

## Use it

```c#
public void EsValidationSample(IEnumerable<IIdentityNumberValidator> countryValidators)
{
  // NOTE: we can get IEnumerable<IIdentityNumberValidator> and country code from Dependency Injection
  var validator = countryValidators.First(countryValidator => countryValidator.IsCountry("ES"));
  Console.WriteLine(validator.IsValid("A50923085"));  // true -> valid CIF
  Console.WriteLine(validator.IsValid("14333663V"));  // true -> valid DNI
  Console.WriteLine(validator.IsValid("Z2463117Y"));  // true -> valid NIE
  Console.WriteLine(validator.IsValid("z2463117y"));  // true -> camelcase insensitive
  Console.WriteLine(validator.IsValid("A50921085"));  // false -> wrong CIF checksum
  Console.WriteLine(validator.IsValid("14333664V"));  // false -> wrong DNI checksum
  Console.WriteLine(validator.IsValid("Z1463117Y"));  // false -> wrong NIE checksum
  Console.WriteLine(validator.IsValid("A50923085", "CIF"));  // true -> valid CIF of same type
  Console.WriteLine(validator.IsValid("A50923085", "DNI"));  // false -> valid CIF but we are asking for DNI type
  Console.WriteLine(validator.IsValid("14333663V", "NIF"));  // true -> DNI is also NIF
  Console.WriteLine(validator.IsValid("Z2463117Y", "nif"));  // true -> NIE is also NIF
  Console.WriteLine(validator.IsValid("A50923085", "NIF"));  // false -> CIF is not NIF
}
```

## Generate

So far, this is only specific to each country implementation.

```c#
public void EsGenerationSample(IEnumerable<ISpanishDocument> spanishDocuments)
{
  var nie = spanishDocuments.First(document => document.MatchType("nie"));
  Console.WriteLine(nie.Generate());  // random valid NIE generated
  
  var dni = spanishDocuments.First(document => document.MatchType("dni"));
  Console.WriteLine(dni.Generate());  // random valid DNI generated
  
  var cif = spanishDocuments.First(document => document.MatchType("cif"));
  Console.WriteLine(cif.Generate());  // random valid CIF generated
}
```

## References
- [Cálculo del CIF](http://www.jagar.es/economia/ccif.htm)
- [Generador DNI](https://www.generador-de-dni.com/generador-de-dni)
- [Calculating the NIF/NIE check digit](https://www.ordenacionjuego.es/en/calculo-digito-control)
- [Cálculo del dígito de control del NIF/NIE](https://www.interior.gob.es/opencms/es/servicios-al-ciudadano/tramites-y-gestiones/dni/calculo-del-digito-de-control-del-nif-nie/)
