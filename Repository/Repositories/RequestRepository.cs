using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFS.Core;
namespace RFS.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(RFSContext context) : base(context)
        {
        }

        public IEnumerable<Request> GetLatestTopRequests(int count)
        {
            return RFSContext.Requests.OrderByDescending(r => r.ID).Take(count).ToList();
        }

        public IEnumerable<Request> GetTopLateRequests(int pageIndex, int pageSize = 10)
        {
            return RFSContext.Requests.OrderBy(r => r.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public RFSContext RFSContext
            {get { return context as RFSContext; } }
    }
}
