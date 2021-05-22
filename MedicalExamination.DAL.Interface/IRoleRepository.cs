using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Responses.Role;
using MedicalExamination.Domain.Requests.Role;


namespace MedicalExamination.DAL.Interface
{
   public interface IRoleRepository
    {
        public Task<CreateRoleRes> CreateNewRole(CreateRoleReq newRole);

        public Task<UpdateRoleRes> UpdateRole(UpdateRoleReq updateRole);

    }
}
