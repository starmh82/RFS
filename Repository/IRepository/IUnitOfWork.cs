using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDeletionRequestRepository DeletionRequests { get; }
        int Complete();
    }
}
