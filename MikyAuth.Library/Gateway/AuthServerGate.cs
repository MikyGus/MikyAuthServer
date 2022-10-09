using Microsoft.AspNetCore.Identity;
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
        AuthUser user = new AuthUser()
        {
            //Id = Guid.NewGuid(),
            UserName = newUser.Username,
            //NormalizedUserName = newUser.Username.Normalize().ToLower(),
        };
        var result = await _userManager.CreateAsync(user);

    }
}
