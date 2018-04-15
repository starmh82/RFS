using RFS.Core;
using System.Collections.Generic;

namespace RFS.Repositories
{
    public interface IRequestRepository : IRepository<Request>
    {
        IEnumerable<Request> GetLatestTopRequests(int count);
        IEnumerable<Request> GetTopLateRequests(int pageIndex, int pageSize);
    }
}
