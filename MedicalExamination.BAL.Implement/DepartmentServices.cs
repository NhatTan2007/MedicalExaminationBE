using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Department;
using MedicalExamination.Domain.Responses.Department;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
   public class DepartmentServices : IDepartmentServices
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRespository)
        {
            _departmentRepository = departmentRespository;
        }

        public async Task<CreateDepartmentRes> CreateDepartment(CreateDepartmentReq request)
        {
            return await _departmentRepository.CreateDepartment(request);
        }

        public async Task<Department> GetDepartmentById(string departmentId)
        {
            return await _departmentRepository.GetDepartmentById(departmentId);
        }

        public async Task<UpdateDepartmentRes> UpdateDepartment(UpdateDepartmentReq request)
        {
            return await _departmentRepository.UpdateDepartment(request);
        }
    }
}
