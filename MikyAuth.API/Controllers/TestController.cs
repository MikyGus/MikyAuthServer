using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MikyAuth.Library.Entities;
using MikyAuth.Library.Gateway;

namespace MikyAuth.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    //UserManager<AuthUser> _userManager;
    private IAuthServerGate _authServerGate;
    public TestController(IAuthServerGate authServerGate)
    {
        //_userManager = userManager;
        _authServerGate = authServerGate;
    }

    //[HttpGet]
    //public async Task<IActionResult> TestAsync()
    //{
    //    AuthUser user = new AuthUser()
    //    {
    //        UserName = "Miky",
    //        NormalizedUserName = "miky"
    //    };
    //    var result = await _userManager.CreateAsync(user);
    //    if (result.Succeeded)
    //    {
    //        var finalResult = await _userManager.UpdateAsync(user);
    //    }
    //    return Ok();
    //}

    [HttpGet]
    public async Task<IActionResult> AuthServerGate()
    {
        var user = new UserCreateDto("Miky");
        await _authServerGate.CreateUser(user);
        return Ok();
    }

    [Authorize]
    [HttpGet]
    [Route("Secret")]
    public IActionResult Secret()
    {
        return Ok();
    }
}
