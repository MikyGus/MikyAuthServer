using Microsoft.AspNetCore.Identity;
using MikyAuth.Library.Entities;
using MikyAuth.Library.PersistentStorage;

namespace MikyAuth.Library.Stores;
internal sealed class UserStore : IUserStore<AuthUser>
{
    private IDbAccess _dbAccess;
    public UserStore(IDbAccess dbAccess)
    {
        _dbAccess = dbAccess;
    }

    public Task<IdentityResult> CreateAsync(AuthUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityResult> DeleteAsync(AuthUser user, CancellationToken cancellationToken) => throw new NotImplementedException();
    public void Dispose()
    {
        // Does nothing
    }

    public Task<AuthUser> FindByIdAsync(string userId, CancellationToken cancellationToken) => throw new NotImplementedException();
    public Task<AuthUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var TaskUser = Task.FromResult(_dbAccess.FindUser(normalizedUserName));
        return TaskUser;
    }

    public Task<string> GetNormalizedUserNameAsync(AuthUser user, CancellationToken cancellationToken)
        => Task.FromResult(user.NormalizedUserName);
    public Task<string> GetUserIdAsync(AuthUser user, CancellationToken cancellationToken)
        => Task.FromResult(user.Id.ToString());
    public Task<string> GetUserNameAsync(AuthUser user, CancellationToken cancellationToken)
        => Task.FromResult(user.UserName);

    public Task SetNormalizedUserNameAsync(AuthUser user, string normalizedName, CancellationToken cancellationToken)
        => Task.FromResult(user.NormalizedUserName = normalizedName);
    public Task SetUserNameAsync(AuthUser user, string userName, CancellationToken cancellationToken) => throw new NotImplementedException();
    public Task<IdentityResult> UpdateAsync(AuthUser user, CancellationToken cancellationToken)
    {
        // TODO: Use real database!!
        return Task.FromResult(IdentityResult.Success);
    }
}
