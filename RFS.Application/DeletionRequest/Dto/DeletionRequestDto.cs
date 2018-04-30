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
    public class DeletionRequestDto
    {
        [Key]
        public int ID { get;set; }
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
        public DateTime CreatedAt { get; protected set; }

        public DeletionRequestDto FromDeletionRequest(DeletionRequest req)
        {
            return new DeletionRequestDto
            {
                ID = req.ID,
                CreatedAt = req.CreatedAt,
                DeletionDate = req.DeletionDate,
                MemberName = req.MemberName,
                MemberShipNo = req.MemberShipNo,
                Nationality = req.Nationality,
                Status = req.Status

            };
        }

        internal DeletionRequest UpdateDeletionRequest(DeletionRequest request)
        {
            request.DeletionDate = this.DeletionDate;
            request.MemberName = this.MemberName;
            request.MemberShipNo = this.MemberShipNo;
            request.Nationality = this.Nationality;
            request.Status = this.Status;
            request.Reason = this.Reason;
            return request;
        }
    }
}
