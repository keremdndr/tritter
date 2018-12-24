using System.Collections.Generic;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritModel;

namespace TP.Business.Contracts
{
    public interface ITritEngine : IBusinessEngine
    {
        Result<TritUpdateModel> Get(int id);

        Result Create(TritCreateModel tritCreateModel);

        Result Update(TritUpdateModel tritUpdateModel);

        Result Delete(int id);

        Result<List<TritListModel>> GetAll();

        Result<List<TritListModel>> GetTritsByUserId(string user_id);

        Result<List<TritOthersListModel>> GetTritsOfOthers(string user_id);

        //Result SendTritToDB(string user_id, string trit);

    }
}