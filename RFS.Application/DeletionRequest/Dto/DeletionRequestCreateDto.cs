using RFS.Core;
using RFS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Application.Dto
{
    public class DeletionRequestCreateDto
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
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; protected set; }

        public DeletionRequest ToDeletionRequest()
        {
            return new DeletionRequest
            {
                DeletionDate = this.DeletionDate,
                MemberName = this.MemberName,
                MemberShipNo = this.MemberShipNo,
                Nationality = this.Nationality,
                Status = this.Status,
                DeletionReasonId = this.DeletionReasonId
            };
        }
    }
}
