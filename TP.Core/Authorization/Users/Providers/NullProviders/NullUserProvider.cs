using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Users.Providers.NullProviders
{
    public sealed class NullUserProvider<TUser> : IUserProvider<TUser>
        where TUser : class
    {
        public TUser GetUser(string username)
        {
            return null;
        }

        public Task<TUser> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            return Task.FromResult<TUser>(null);
        }
    }
}
