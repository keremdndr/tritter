using System.Threading;
using System.Threading.Tasks;

namespace TP.Core.Authorization.Permissions.Checkers
{
    public interface IPermissionChecker<TPermission>
    {
        bool IsGranted(int userId, TPermission permission);

        Task<bool> IsGrantedAsync(int userId, TPermission permission, CancellationToken cancellationToken);
    }
}
