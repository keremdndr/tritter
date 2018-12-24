using System;
using System.Collections.Generic;
using System.Text;
using TP.Data.Entities.PageModels.TritModel;
using TP.Data.Entities.PageModels.UserModel;

namespace TP.Data.Entities.PageModels.ProfilePageModel
{
    public class ProfilePageUserModel
    {
        public List<TritListModel> TritListModel { get; set; }

        public UserCreateModel UserCreateModel { get; set; }
    }
}
