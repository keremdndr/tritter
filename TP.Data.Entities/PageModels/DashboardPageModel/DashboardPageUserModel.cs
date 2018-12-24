using System;
using System.Collections.Generic;
using System.Text;
using TP.Data.Entities.PageModels.TritModel;
using TP.Data.Entities.PageModels.UserModel;

namespace TP.Data.Entities.PageModels.DashboardPageModel
{
    public class DashboardPageUserModel
    {
        public List<TritOthersListModel> TritOthersListModel { get; set; }

        public UserCreateModel UserCreateModel { get; set; }
    }
}
