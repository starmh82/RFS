using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RFSContext _context;

        public UnitOfWork(RFSContext context)
        {
            _context = context;
            Requests = new RequestRepository(_context);
        }

        public IRequestRepository Requests { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
