using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.GroupMedicalExamination;
using MedicalExamination.Domain.Responses.GroupMedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
   public class GMExaminationServices : IGMExaminationServices
    {
        private IGMExaminationRepository _gMExaminationRepository;
        public GMExaminationServices(IGMExaminationRepository gMExaminationRepository)
        {
            _gMExaminationRepository = gMExaminationRepository;
        }

        public async Task<CreateGMExaminationRes> CreateGMExamination(CreateGMExaminationReq request)
        {
            return await _gMExaminationRepository.CreateGMExamination(request);
        }

        public async Task<IEnumerable<GroupMedicalExamination>> GetAllGMExaminations()
        {
            return await _gMExaminationRepository.GetAllGMExaminations(); 
        }

     
        public async Task<GroupMedicalExamination> GetGMExaminationById(string GMExaminationId)
        {
            return await _gMExaminationRepository.GetGMExaminationById(GMExaminationId);
        }

        public async Task<IEnumerable<GroupMedicalExamination>> GetGMExaminationByOrganizationId(string OrganizationId)
        {
            return await _gMExaminationRepository.GetGMExaminationByOrganizationId(OrganizationId);
        }

        public async Task<UpdateGMExaminationRes> UpdateGMExamination(UpdateGMExaminationReq request)
        {
            return await _gMExaminationRepository.UpdateGMExamination(request);
        }


    }
}
