using MikyAuth.Library.Entities;

namespace MikyAuth.Library.PersistentStorage;
internal interface IDbAccess
{
    AuthUser FindUser(string normalizedUserName);
}