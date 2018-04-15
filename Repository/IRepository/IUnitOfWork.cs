using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository Requests { get; }
        int Complete();
    }
}
