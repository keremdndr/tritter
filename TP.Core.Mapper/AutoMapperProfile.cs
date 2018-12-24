using AutoMapper;
using System.Linq;
using TP.Data.Entities;

using TP.Data.Entities.PageModels.UserModel;

namespace TP.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region [User]

            CreateMap<User, UserCreateModel>().ReverseMap();
            CreateMap<User, UserUpdateModel>().ReverseMap();
            CreateMap<User, UserListModel>().ReverseMap();

            #endregion [User]
        }

        protected AutoMapperProfile(string profileName) : base(profileName)
        {
        }
    }
}