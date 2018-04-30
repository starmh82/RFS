using RFS.Application.Dto;
using RFS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Application
{
    public class DeletionRequestService
    {
        public static DeletionRequestService Instance { get; private set; }
        private readonly DeletionRequestRepository drRepository;

        private DeletionRequestService()
        {
            drRepository = new DeletionRequestRepository();
        }
        static DeletionRequestService()
        {
            Instance = new DeletionRequestService();
        }

        public List<DeletionRequestDto> GetAllRequests()
        {
            var requests = drRepository.GetLatestTopRequests(10);

            List<DeletionRequestDto> drList = new List<DeletionRequestDto>();
            foreach (var req in requests) drList.Add(new DeletionRequestDto().FromDeletionRequest(req));

            return drList;
        }

        public void CreateDeletionRequest(DeletionRequestCreateDto model)
        {
            drRepository.Add(model.ToDeletionRequest());
            drRepository.Save();
        }


        public void UpdateDeletionRequest(DeletionRequestDto model)
        {
            var request = drRepository.Get(model.ID);
            drRepository.Update(model.UpdateDeletionRequest(request));
            drRepository.Save();
        }

        public void Delete(DeletionRequestDto model)
        {
            var user = drRepository.Get(model.ID);
            drRepository.Remove(user);
            drRepository.Save();
        }

        public DeletionRequestDto GetRequestByID(int ID)
        {
            var req = drRepository.Get(ID);
            if (req != null)
            {
                return new DeletionRequestDto
                {
                    ID = req.ID,
                    DeletionDate = req.DeletionDate,
                    MemberName = req.MemberName,
                    MemberShipNo = req.MemberShipNo,
                    Nationality = req.Nationality,
                    Status = req.Status,
                    Reason = req.Reason
                };
            }
            return null;
        }
    }
}
