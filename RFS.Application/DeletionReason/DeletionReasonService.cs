using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories;
using RFS.Application.Dto;
using RFS.Core;
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

        public List<DeletionReasonDto> GetAllReasons()
        {
            var reasons = repository.GetAllActiveReasons(r=> r.Active).ToList();

            List<DeletionReasonDto> reasonsList = new List<DeletionReasonDto>();
            foreach (var res in reasons) reasonsList.Add(new DeletionReasonDto().FromDeletionReason(res));

            return reasonsList;
        }
    }
}
