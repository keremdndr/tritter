using System.Collections.Generic;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritModel;

namespace TP.Data.Contracts
{
    public interface ITritRepository : IGenericRepository<TPContext, Trit>
    {
        List<TritOthersListModel> GetTritOthers(string user_id);
    }
}