using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MikyAuth.Library.Entities;
using MySql.Data.MySqlClient;

namespace MikyAuth.Library.PersistentStorage;
internal sealed class DbAccessMySql : IDbAccess
{
    private readonly AuthServerOption _options;

    public DbAccessMySql(IOptions<AuthServerOption> options)
    {
        _options = options.Value;
    }

    public AuthUser FindUser(string normalizedUserName)
    {
        using MySqlConnection connection = new(_options.ConnectionString);
        string sql = "SELECT Id, Username, NormalizedUsername " +
            "FROM auth_user " +
            "WHERE NormalizedUsername = @normalizedUserName";
        AuthUser user = connection.QuerySingleOrDefault<AuthUser>(sql, new
        {
            @NormalizedUserName = normalizedUserName,
        });
        return user;
    }

    public async Task<IdentityResult> CreateUserAsync(AuthUser user)
    {
        using MySqlConnection connection = new(_options.ConnectionString);
        string sql = "INSERT INTO auth_user " +
                "(Id, UserName, NormalizedUsername) " +
                "VALUES(@Id, @UserName, @NormalizedUsername)"; 
        
        int rowsInserted = await connection.ExecuteAsync(sql, user);

        if (rowsInserted == 1)
        {
            return IdentityResult.Success;
        }

        var error = new IdentityError()
        {
            Code = "Failure creating new user",
            Description = "Failure creating new user"
        };
        return IdentityResult.Failed(error);
        
    }
}
