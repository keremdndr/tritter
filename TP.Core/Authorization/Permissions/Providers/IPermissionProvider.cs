using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Permissions.Providers
{
    public interface IPermissionProvider<TPermission>
    {
        TPermission[] GetPermissions(int userId);
        Task<TPermission[]> GetPermissionsAsync(int userId, CancellationToken cancellationToken);
    }
}
