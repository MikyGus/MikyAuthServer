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
            UserName = "Miky",
            //NormalizedUserName = "miky"
        };
        var result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            var finalResult = await _userManager.UpdateAsync(user);
        }
    }
}
