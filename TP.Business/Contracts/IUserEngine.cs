using System.Collections.Generic;
using TP.Data.Entities;
using TP.Data.Entities.PageModels.UserModel;

namespace TP.Business.Contracts
{
    public interface IUserEngine : IBusinessEngine
    {
        Result<UserUpdateModel> Get(int id);

        Result Create(UserCreateModel userCreateModel);

        Result Update(UserUpdateModel userUpdateModel);

        Result Delete(int id);

        Result<List<UserListModel>> GetAll();

        Result CheckUserLogin(string username, string password);

        Result<UserCreateModel> GetByUserId(string user_id);

        Result<List<UserListModel>> SearchUser(string word);

    }
}