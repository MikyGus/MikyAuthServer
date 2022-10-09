using Microsoft.AspNetCore.Identity;
using MikyAuth.Library.Converters;
using MikyAuth.Library.Entities;

namespace MikyAuth.Library.Gateway;
internal sealed class AuthServerGate : IAuthServerGate
{
    private UserManager<AuthUser> _userManager;
    public AuthServerGate(UserManager<AuthUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUser(UserCreateDto newUser)
    {
        AuthUser user = newUser.ConvertToAuthUser();
        var result = await _userManager.CreateAsync(user);

    }
}
