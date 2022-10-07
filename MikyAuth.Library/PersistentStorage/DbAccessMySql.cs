using Dapper;
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
        //var parameters = new { NormalizedUserName = normalizedUserName };
        using MySqlConnection connection = new(_options.ConnectionString);
        string sql = "SELECT Id, Username, NormalizedUsername FROM auth_user WHERE NormalizedUsername = @normalizedUserName";
        AuthUser user = connection.QuerySingleOrDefault<AuthUser>(sql, new
        {
            @NormalizedUserName = normalizedUserName,
        });
        return user;
    }
}
