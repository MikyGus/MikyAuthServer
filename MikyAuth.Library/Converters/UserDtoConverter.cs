using MikyAuth.Library.Entities;
using MikyAuth.Library.Gateway;

namespace MikyAuth.Library.Converters;
internal static class UserDtoConverter
{
    public static AuthUser ConvertToAuthUser(this UserCreateDto user)
    {
        AuthUser authUser = new()
        {
            // Not needed, gets correct value automaticly when
            // a new AuthUser is instantiated or later by Identity
            //
            // Id = Guid.NewGuid(), 
            // NormalizedUserName = String.Empty,

            UserName = user.Username,
        };
        return authUser;
    }
}
