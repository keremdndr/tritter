using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Permissions.Checkers.NullCheckers
{
    public sealed class AlwaysGrantedPermissionChecker<TPermission> : IPermissionChecker<TPermission>
    {
        public bool IsGranted(int userId, TPermission permission)
        {
            return true;
        }

        public Task<bool> IsGrantedAsync(int userId, TPermission permission, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
