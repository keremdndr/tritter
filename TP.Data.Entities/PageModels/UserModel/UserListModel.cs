using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Data.Entities.PageModels.UserModel
{
    public class UserListModel
    {
        public string user_id { get; set; }

        public string user_username { get; set; }

        public string user_name { get; set; }

        public string user_surname { get; set; }

        public string user_email { get; set; }

        public string user_password { get; set; }

        public int user_isactive { get; set; }

        public DateTime user_createtime { get; set; }
    }
}