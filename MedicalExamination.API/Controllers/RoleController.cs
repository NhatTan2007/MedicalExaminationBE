using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Role;
using MedicalExamination.Domain.Responses.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class RoleController : BaseApiController
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        /// <summary>
        /// Create new Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response about create new Role</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateNewRole(CreateRoleReq request)
        {
            return Ok(await _roleService.CreateNewRole(request));
        }

        /// <summary>
        /// Create new Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response about create new Role</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole(UpdateRoleReq request)
        {
            var result = await _roleService.UpdateRole(request);
            if (result != null) return Ok(result);
            return BadRequest();
        }
    }
}
