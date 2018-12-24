using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP.Data.Entities
{
    public class BaseEntity : IAuditable, ISoftDeletable
    {
    //    [Key]
    //    [Column(Order = 0)]
    //    public int Id { get; set; }

    //    [Required]
    //    public int CreatedById { get; set; }

    //    [StringLength(50)]
    //    [Required]
    //    public string CreatedByCode { get; set; }

    //    [Column(TypeName = "DateTime")]
    //    [Required]
    //    public DateTime CreatedTime { get; set; }

    //    public int? UpdatedById { get; set; }

    //    [StringLength(50)]
    //    public string UpdatedByCode { get; set; }

    //    [Column(TypeName = "DateTime")]
    //    public DateTime? UpdatedTime { get; set; }

    //    public Guid? GcRecordId { get; set; }
    }
}