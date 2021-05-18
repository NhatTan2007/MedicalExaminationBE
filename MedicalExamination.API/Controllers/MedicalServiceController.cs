using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.MedicalService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class MedicalServiceController: BaseApiController
    {
        private readonly IMedicalServiceService _medicalServiceService;

        public MedicalServiceController(IMedicalServiceService medicalServiceService)
        {
            _medicalServiceService = medicalServiceService;
        }

        /// <summary>
        /// Get all medical services
        /// </summary>
        /// <returns>List medical services </returns>
        [HttpGet("")]
        public async Task<IActionResult> GetMedicalServices()
        {
            return Ok(await _medicalServiceService.GetMedicalServices());
        }
        /// <summary>
        /// GetMedicalServicesBypagination
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("currentPage/{currentPage}/pageSize/{pageSize}")]

        public async Task<IActionResult> GetMedicalServicesBypagination(int currentPage, int pageSize)
        {
            return Ok(await _medicalServiceService.GetMedicalServicesBypagination(currentPage, pageSize));
        }

        /// <summary>
        /// Get active medical services
        /// </summary>
        /// <returns>List medical services </returns>
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMedicalServices()
        {
            return Ok(await _medicalServiceService.GetActiveMedicalServices());
        }

        /// <summary>
        /// GetActiveMedicalServicesBypagination
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("active/currentPage/{currentPage}/pageSize/{pageSize}")]

        public async Task<IActionResult> GetActiveMedicalServicesBypagination(int currentPage, int pageSize)
        {
            return Ok(await _medicalServiceService.GetActiveMedicalServicesBypagination(currentPage, pageSize));
        }

        /// <summary>
        /// Create a new medical service
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when create a new medical service</returns>
        [HttpPost("create")]
       public async Task<IActionResult> CreateMedicalService(CreateMedicalServiceReq request)
        {
            return Ok(await _medicalServiceService.CreateMedicalService(request));
        }

        /// <summary>
        /// Update medical service data
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when update data of a medical service</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMedicalService(UpdateMedicalServiceReq request)
        {
            return Ok(await _medicalServiceService.UpdateMedicalService(request));
        }

        /// <summary>
        /// Get specific medical service by Id
        /// </summary>
        /// <param name="medicalServiceId"></param>
        /// <returns>A medical service</returns>
        [HttpGet("{medicalServiceId}")]
        public async Task<IActionResult> GetMedicalServiceByMedicalServiceId(string medicalServiceId)
        {
            return Ok(await _medicalServiceService.GetMedicalServiceByMedicalServiceId(medicalServiceId));
        }

        /// <summary>
        /// Get list of medical service by department Id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>A list of medical service</returns>
        [HttpGet("departmentId/{departmentId}")]

        public async Task<IActionResult> GetMedicalServiceByDepartmentId(string departmentId)
        {
            return Ok(await _medicalServiceService.GetMedicalServiceByDepartmentId(departmentId));
        }

        /// <summary>
        /// SearchByNameMServicePagination
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("search/{keyword}/currentPage/{currentPage}/pageSize/{pageSize}")]
        public async Task<IActionResult> SearchByNameMServicePagination(string keyword, int currentPage, int pageSize)
        {
            return Ok(await _medicalServiceService.SearchByNameMServicePagination(keyword, currentPage, pageSize));
        }
    }
}
