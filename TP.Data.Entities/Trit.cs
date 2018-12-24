using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TP.Data.Entities
{
    [Table(name: "TB_Trit")]
    public class Trit : BaseEntity
    {
        [Key]
        [Required]
        [StringLength(255)]
        [Column(Order = 1)]
        public int trit_id { get; set; }

        [Required]
        [StringLength(255)]
        [Column(Order = 1)]
        public string trit_user_id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order = 2)]
        public DateTime trit_time { get; set; }

        [Required]
        [StringLength(255)]
        [Column(Order = 3)]
        public string trit_text { get; set; }

    }
}