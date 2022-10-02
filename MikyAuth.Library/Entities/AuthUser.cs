namespace MikyAuth.Library.Entities;
internal sealed class AuthUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserName { get; set; } = string.Empty;
    public string NormalizedUserName { get; set; } = string.Empty;

}
