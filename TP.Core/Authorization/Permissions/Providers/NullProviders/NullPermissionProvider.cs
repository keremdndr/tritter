using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Permissions.Providers.NullProviders
{
    public class NullPermissionProvider<TPermission> : IPermissionProvider<TPermission>
    {
        public TPermission[] GetPermissions(int userId)
        {
            return null;
        }

        public Task<TPermission[]> GetPermissionsAsync(int userId, CancellationToken cancellationToken)
        {
            return Task.FromResult<TPermission[]>(null);
        }
    }
}
