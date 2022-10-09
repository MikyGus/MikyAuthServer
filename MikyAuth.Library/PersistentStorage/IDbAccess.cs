using Microsoft.AspNetCore.Identity;
using MikyAuth.Library.Entities;

namespace MikyAuth.Library.PersistentStorage;
internal interface IDbAccess
{
    AuthUser FindUser(string normalizedUserName);
    Task<IdentityResult> CreateUserAsync(AuthUser user);
}