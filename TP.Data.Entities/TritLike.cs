using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TP.Data.Entities
{
    [Table(name: "TB_Trit_Likes")]
    public class TritLike : BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int like_id { get; set; }

        [Required]
        [Column(Order = 2)]
        public int trit_id { get; set; }

        [Required]
        [StringLength(255)]
        [Column(Order = 3)]
        public string like_user_id { get; set; }

        [Required]
        [Column(Order = 4)]
        public int like_status { get; set; }
    }
}