using Microsoft.AspNetCore.Identity;
using MikyAuth.Library.Entities;

namespace MikyAuth.Library.Stores;
internal sealed class UserStore : IUserStore<AuthUser>
{
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
        //TODO: Get info from DB!
        return Task.FromResult<AuthUser>(null);
    }

    public Task<string> GetNormalizedUserNameAsync(AuthUser user, CancellationToken cancellationToken)
        => Task.FromResult(user.NormalizedUserName);
    public Task<string> GetUserIdAsync(AuthUser user, CancellationToken cancellationToken)
        => Task.FromResult(user.Id);
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
