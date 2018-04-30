using RFS.Core;
using System.Collections.Generic;

namespace RFS.Repositories
{
    public interface IDeletionRequestRepository : IRepository<DeletionRequest>
    {
        IEnumerable<DeletionRequest> GetLatestTopRequests(int count);
        IEnumerable<DeletionRequest> GetTopLateRequests(int pageIndex, int pageSize);
    }
}
