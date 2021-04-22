using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.Department;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        /// <summary>
        /// Get a department by id
        /// </summary>
        /// <returns>A Department detail</returns>
        [HttpGet("api/Department/GetDepartment/{departmentId}")]
        public async Task<IActionResult> GetDepartmentById(string departmentId)
        {
            return Ok(await _departmentServices.GetDepartmentById(departmentId));
        }

        ///<summary>
        ///Create a new department
        ///</summary>
        ///<param name="request"></param>
        ///<returns>New Department</returns>
        [HttpPost("api/Department/CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentReq request)
        {
            return Ok(await _departmentServices.CreateDepartment(request));
        }

        /// <summary>
        /// Update new department
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Department updated</returns>
        [HttpPut("api/Department/UpdateDepartment")]
        public async Task<IActionResult> UpdateOrangization(UpdateDepartmentReq request)
        {
            return Ok(await _departmentServices.UpdateDepartment(request));
        }

    }
}
