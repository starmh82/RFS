using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core;
namespace RFS.Repositories
{
    public class DeletionRequestRepository : Repository<DeletionRequest>, IDeletionRequestRepository
    {
        public DeletionRequestRepository() : base(new RFSContext())
        {
        }

        public IEnumerable<DeletionRequest> GetLatestTopRequests(int count)
        {
            return RFSContext.DeletionRequests.OrderByDescending(r => r.ID).Take(count).ToList();
        }

        public IEnumerable<DeletionRequest> GetTopLateRequests(int pageIndex, int pageSize = 10)
        {
            return RFSContext.DeletionRequests.OrderBy(r => r.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public RFSContext RFSContext
            {get { return context as RFSContext; } }
    }
}
