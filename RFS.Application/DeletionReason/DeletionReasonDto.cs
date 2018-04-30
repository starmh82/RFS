using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core;

namespace RFS.Application.Dto
{
    public class DeletionReasonDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        internal DeletionReasonDto FromDeletionReason(DeletionReason res)
        {
            return new DeletionReasonDto
            {
                Id = res.Id,
                Title = res.Title
            };
        }
    }
}
