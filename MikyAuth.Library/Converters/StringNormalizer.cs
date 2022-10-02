using Microsoft.AspNetCore.Identity;

namespace MikyAuth.Library.Converters;
internal sealed class StringNormalizer : ILookupNormalizer
{
    public string NormalizeEmail(string email) => 
        email.Normalize().ToLowerInvariant();
    public string NormalizeName(string name) => 
        name.Normalize().ToLowerInvariant();
}
