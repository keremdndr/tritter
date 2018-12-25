using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TP.Core;

namespace TP.Data.Entities.PageModels.TritLikeModel
{
    public class TritLikeCreateModel
    {
        [DisplayName("TritLike Id")]
        [Required(ErrorMessage = Keywords.Required)]
        public int like_id { get; set; }

        [DisplayName("Trit Id")]
        [Required(ErrorMessage = Keywords.Required)]
        public int trit_id { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("TritLike UserId")]
        [StringLength(255)]
        public string like_user_id { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("TritLikeStatus")]
        public int like_status { get; set; }

    }
}