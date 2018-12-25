using System.Collections.Generic;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.TritLikeModel;

namespace TP.Business.Contracts
{
    public interface ITritLikeEngine : IBusinessEngine
    {

        Result Create(TritLikeCreateModel tritLikeCreateModel);

        //Result Update(TritUpdateModel tritUpdateModel);

        //Result Delete(int id);

        //Result<List<TritListModel>> GetAll();

        //Result<List<TritListModel>> GetTritsByUserId(string user_id);

        //Result<List<TritOthersListModel>> GetTritsOfOthers(string user_id);

        //Result SendTritToDB(string user_id, string trit);

    }
}