using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core.Enums;

namespace RFS.Core
{
    public class DeletionReason
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        [Required]
        public NationalityType Type { get; set; }
        public bool Active { get; set; }


    }

}
