using RFS.Core;
using RFS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
   public class DeletionReasonRepository : Repository<DeletionRequest>
    {
        public DeletionReasonRepository() : base(new RFSContext())
        {
        }

        public IEnumerable<DeletionReason> GetReasons( Func<DeletionReason,bool> filter)
        {
            return RFSContext.DeletionReasons.Where(filter).ToList();
        }

       
        public RFSContext RFSContext
        { get { return context as RFSContext; } }
    }
}
