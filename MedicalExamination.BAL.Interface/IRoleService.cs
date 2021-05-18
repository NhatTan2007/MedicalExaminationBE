using MedicalExamination.Domain.Requests.Role;
using MedicalExamination.Domain.Responses.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
   public interface IRoleService
    {
        Task<CreateRoleRes> CreateNewRole(CreateRoleReq request);
        Task<UpdateRoleRes> UpdateRole(UpdateRoleReq updateRole);
    }
}
