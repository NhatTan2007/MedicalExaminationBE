using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain;
using MedicalExamination.Domain.Responses.GroupMedicalExamination;
using MedicalExamination.Domain.Requests.GroupMedicalExamination;

namespace MedicalExamination.DAL.Interface
{
   public interface IGMExaminationRepository
    {
      
        Task<IEnumerable<GroupMedicalExamination>> GetAllGMExaminations();
        Task<GroupMedicalExamination> GetGMExaminationById(string GMExaminationId);
        Task<IEnumerable<GroupMedicalExamination>> GetGMExaminationByOrganizationId(string OrganizationId);
        Task<CreateGMExaminationRes> CreateGMExamination(CreateGMExaminationReq request);
        Task<UpdateGMExaminationRes> UpdateGMExamination(UpdateGMExaminationReq request);
    }
}
