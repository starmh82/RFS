using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories;
using RFS.Application.Dto;
using RFS.Core;
using RFS.Core.Enums;
using RFS.Repositories;

namespace RFS.Application
{
    public class DeletionReasonService
    {
        public static DeletionReasonService Instance { get; private set; }
        private readonly DeletionReasonRepository repository;

        private DeletionReasonService()
        {
            repository = new DeletionReasonRepository();
        }
        static DeletionReasonService()
        {
            Instance = new DeletionReasonService();
        }

        public List<DeletionReasonDto> GetReasons(int? nationalityType)
        {
            IEnumerable<DeletionReason> reasons;
            if (nationalityType.HasValue)
                 reasons = repository.GetReasons(r =>( r.Type == (NationalityType)nationalityType) && r.Active).ToList();
            else
                 reasons = repository.GetReasons(r=> r.Active).ToList();

            List<DeletionReasonDto> reasonsList = new List<DeletionReasonDto>();
            foreach (var res in reasons) reasonsList.Add(new DeletionReasonDto().FromDeletionReason(res));

            return reasonsList;
        }
    }
}
