using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.MedicalService;
using MedicalExamination.Domain.Responses.MedicalService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class MedicalServiceService : IMedicalServiceService
    {
        private readonly IMedicalServiceRepository _medicalServiceRepository;

        public MedicalServiceService(IMedicalServiceRepository medicalServiceRepository)
        {
            _medicalServiceRepository = medicalServiceRepository;
        }
        public async Task<CreateMedicalServiceRes> CreateMedicalService(CreateMedicalServiceReq request)
        {
            return await _medicalServiceRepository.CreateMedicalService(request);
        }

        public async Task<IEnumerable<MedicalService>> GetActiveMedicalServices()
        {
            return await _medicalServiceRepository.GetActiveMedicalServices();
        }

        public async Task<QueryMServiceRes> GetMedicalServicesByPagination(int currentPage, int pageSize)
        {
            return await _medicalServiceRepository.GetMedicalServicesByPagination(currentPage, pageSize);
        }

        public async Task<IEnumerable<MedicalService>> GetMedicalServiceByDepartmentId(string departmentId)
        {
            return await _medicalServiceRepository.GetMedicalServiceByDepartmentId(departmentId);
        }

        public async Task<MedicalService> GetMedicalServiceByMedicalServiceId(string medicalServiceId)
        {
            return await _medicalServiceRepository.GetMedicalServiceByMedicalServiceId(medicalServiceId);
        }

        public async Task<IEnumerable<MedicalService>> GetMedicalServices()
        {
            return await _medicalServiceRepository.GetMedicalServices();
        }
        public async Task<QueryMServiceRes> GetActiveMedicalServicesByPagination(int currentPage, int pageSize)
        {
            return await _medicalServiceRepository.GetActiveMedicalServicesByPagination(currentPage, pageSize);
        }

        public async Task<QueryMServiceRes> SearchByNameMServicePagination(string keyword, int currentPage, int pageSize)
        {
            return await _medicalServiceRepository.SearchByNameMServicePagination(keyword, currentPage, pageSize);
        }

        public async Task<UpdateMedicalServiceRes> UpdateMedicalService(UpdateMedicalServiceReq request)
        {
            return await _medicalServiceRepository.UpdateMedicalService(request);
        }
    }
}
