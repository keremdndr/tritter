using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TP.Core;

namespace TP.Data.Entities.PageModels.TritModel
{
    public class TritCreateModel
    {
        [DisplayName("Trit Id")]
        [Required(ErrorMessage = Keywords.Required)]
        public int trit_id { get; set; }

        [DisplayName("Trit Sahibi")]
        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(255)]
        public string trit_user_id { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("Trit Zamanı")]
        public DateTime trit_time { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("Trit")]
        public string trit_text { get; set; }

    }
}