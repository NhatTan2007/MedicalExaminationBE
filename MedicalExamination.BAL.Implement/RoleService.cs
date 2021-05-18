using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Role;
using MedicalExamination.Domain.Responses.Role;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<CreateRoleRes> CreateNewRole(CreateRoleReq request)
        {
            return await _roleRepository.CreateNewRole(request);
        }

        public async Task<UpdateRoleRes> UpdateRole(UpdateRoleReq updateRole)
        {
            return await _roleRepository.UpdateRole(updateRole);
        }



    }
}