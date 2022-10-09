using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MikyAuth.Library.Gateway;

namespace MikyAuth.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private IAuthServerGate _authServerGate;
    public TestController(IAuthServerGate authServerGate)
    {
        _authServerGate = authServerGate;
    }

    [HttpGet]
    public async Task<IActionResult> AuthServerGate(UserCreateDto newUser)
    {
        await _authServerGate.CreateUser(newUser);
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
