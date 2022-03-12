using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "S927", Justification = "We have decided ignore this in MediatR types", MessageId = "request")]
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "ASP.NET Core doesn't use thread context to store request context.", Scope = "module")]
[assembly: SuppressMessage("Design", "S3453:Classes should not have only private constructors", Justification = "Following some DDD patterns we want to instantiate our entities or valueObjects through static methods. In these cases constructors will be private", Scope = "module")] 