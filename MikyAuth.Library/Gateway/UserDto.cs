using System.ComponentModel.DataAnnotations;

namespace MikyAuth.Library.Gateway;
public sealed record UserCreateDto([Required] string Username);
