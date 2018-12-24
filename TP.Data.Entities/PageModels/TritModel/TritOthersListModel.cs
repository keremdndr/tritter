using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Data.Entities.PageModels.TritModel
{
    public class TritOthersListModel
    {
        public int trit_id { get; set; }

        public string trit_user_id { get; set; }

        public DateTime trit_time { get; set; }

        public string trit_text { get; set; }

        //public int trit_like_count { get; set; }

        public string current_user_id { get; set; }

        //public int trit_retrit_count { get; set; }

        public string username { get; set; }
    }
}
