using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TP.Core;

namespace TP.Data.Entities.PageModels.UserModel
{
    public class UserCreateModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(100)]
        public string user_username { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(100)]
        [DisplayName("Ad")]
        public string user_name { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(100)]
        [DisplayName("Soyad")]
        public string user_surname { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(200)]
        [DisplayName("Email")]
        public string user_email { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [StringLength(200)]
        [DisplayName("Şifre")]
        public string user_password { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("Katılma Tarihi")]
        public DateTime user_createtime { get; set; }

        [Required(ErrorMessage = Keywords.Required)]
        [DisplayName("Aktif")]
        public int user_isactive { get; set; }

    }
}