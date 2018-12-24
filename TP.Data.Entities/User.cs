using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TP.Data.Entities
{
    [Table(name: "TB_User")]
    public class User : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [StringLength(100)]
        [Column(Order = 1)]
        public string user_id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order = 1)]
        public string user_name { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order = 2)]
        public string user_surname { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order = 3)]
        public string user_username { get; set; }

        [Required]
        [StringLength(200)]
        [Column(Order = 4)]
        public string user_email { get; set; }

        [Required]
        [StringLength(200)]
        [Column(Order = 4)]
        public string user_password { get; set; }

        [Required]
        [Column(Order = 4)]
        public DateTime user_createtime { get; set; }

        [Required]
        [Column(Order = 4)]
        public int user_isactive { get; set; }
    }
}