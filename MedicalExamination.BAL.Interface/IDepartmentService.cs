using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Department;
using MedicalExamination.Domain.Responses.Department;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(string departmentId);
        Task<CreateDepartmentRes> CreateDepartment(CreateDepartmentReq request);
        Task<UpdateDepartmentRes> UpdateDepartment(UpdateDepartmentReq request);
    }
}
