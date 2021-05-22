using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.MedicalService;
using MedicalExamination.Domain.Responses.MedicalService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Interface
{
    public interface IMedicalServiceRepository
    {
        Task<CreateMedicalServiceRes> CreateMedicalService(CreateMedicalServiceReq request);
        Task<UpdateMedicalServiceRes> UpdateMedicalService(UpdateMedicalServiceReq request);
        Task<IEnumerable<MedicalService>> GetMedicalServiceByDepartmentId(string departmentId);
        Task<MedicalService> GetMedicalServiceByMedicalServiceId(string medicalServiceId);
        Task<IEnumerable<MedicalService>> GetMedicalServices();
        Task<QueryMServiceRes> GetMedicalServicesByPagination(int currentPage, int pageSize);
        Task<IEnumerable<MedicalService>> GetActiveMedicalServices();
        Task<QueryMServiceRes> GetActiveMedicalServicesByPagination(int currentPage, int pageSize);
        Task<QueryMServiceRes> SearchByNameMServicePagination(string keyword, int currentPage, int pageSize);

    }
}
