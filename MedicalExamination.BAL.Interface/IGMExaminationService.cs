using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.GroupMedicalExamination;
using MedicalExamination.Domain.Responses.GroupMedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
   public interface IGMExaminationService
    {
        Task<IEnumerable<GroupMedicalExamination>> GetAllGMExaminations();
        Task<GroupMedicalExamination> GetGMExaminationById(string GMExaminationId);
        Task<IEnumerable<GroupMedicalExamination>> GetGMExaminationByOrganizationId(string OrganizationId);
        Task<CreateGMExaminationRes> CreateGMExamination(CreateGMExaminationReq request);
        Task<UpdateGMExaminationRes> UpdateGMExamination(UpdateGMExaminationReq request);
        
    }
}
