using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.Department;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        /// <summary>
        /// Get a department by id
        /// </summary>
        /// ///<param name="departmentId"></param>
        /// <returns>Specific department</returns>
        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetDepartmentById(string departmentId)
        {
            return Ok(await _departmentServices.GetDepartmentById(departmentId));
        }

        ///<summary>
        ///Create a new department
        ///</summary>
        ///<param name="request"></param>
        ///<returns>Response when create a new department</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentReq request)
        {
            return Ok(await _departmentServices.CreateDepartment(request));
        }

        /// <summary>
        /// Update department data
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when update department data</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrangization(UpdateDepartmentReq request)
        {
            return Ok(await _departmentServices.UpdateDepartment(request));
        }

    }
}
