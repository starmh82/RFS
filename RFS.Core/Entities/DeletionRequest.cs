using System;
using System.ComponentModel.DataAnnotations;
using RFS.Core.Enums;
namespace RFS.Core
{
    public class DeletionRequest: AuditableEntity
    {
        [Key]
        public int ID { get; private set; }
        [Required]
        [StringLength(20)]
        public string MemberShipNo { get; set; }
        [Required]
        [StringLength(50)]
        public string MemberName { get; set; }
        [Required]
        public DateTime DeletionDate { get; set; }
        [Required]
        public NationalityType Nationality { get; set; }
        // Foriegn Key
        public int DeletionReasonId { get; set; }
        public virtual DeletionReason Reason { get; set; }
        public Status Status { get;  set; }

        public DeletionRequest()
        {
            this.SetCreated();
        }
        
    }
}
