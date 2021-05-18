using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.MedicalService;
using MedicalExamination.Domain.Responses.MedicalService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IMedicalServiceService
    {
        Task<CreateMedicalServiceRes> CreateMedicalService(CreateMedicalServiceReq request);
        Task<UpdateMedicalServiceRes> UpdateMedicalService(UpdateMedicalServiceReq request);
        Task<IEnumerable<MedicalService>> GetMedicalServiceByDepartmentId(string departmentId);
        Task<MedicalService> GetMedicalServiceByMedicalServiceId(string medicalServiceId);
        Task<IEnumerable<MedicalService>> GetMedicalServices();
        Task<QuerryMSerciceRes> GetMedicalServicesBypagination(int currentPage, int pageSize);
        Task<IEnumerable<MedicalService>> GetActiveMedicalServices();
        Task<QuerryMSerciceRes> GetActiveMedicalServicesBypagination(int currentPage, int pageSize);

        Task<QuerryMSerciceRes> SearchByNameMServicePagination(string keyword, int currentPage, int pageSize);

    }
}
