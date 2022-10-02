namespace MikyAuth.Library.Gateway;
public interface IAuthServerGate
{
    Task CreateUser(UserCreateDto newUser);
}
