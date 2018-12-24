using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Users.Providers
{
    public interface IUserProvider<TUser>
    {
        TUser GetUser(string username);
        Task<TUser> GetUserAsync(string username, CancellationToken cancellationToken);
    }
}
