using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.OrganizationRes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [Authorize]
    [EnableCors("AllowAllPolicy")]
    public class OrganizationController : BaseApiController
    {
        private readonly IOrganizationsService _organizationsServices;

        public OrganizationController(IOrganizationsService organizationsServices)
        {
            _organizationsServices = organizationsServices;
        }

        /// <summary>
        /// Get all Organizations 
        /// </summary>
        /// <returns>List all Organizations</returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllOrganizations()
        {
            return Ok(await _organizationsServices.GetAllOrganizations());
        }

        /// <summary>
        /// Get Organization by Id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Specific organization has id want to find</returns>
        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationById(string organizationId)
        {
            return Ok(await _organizationsServices.GetOrganizationById(organizationId));
        }

        /// <summary>
        /// GetOrganizationBypagination
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("currentPage/{currentPage}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetOrganizationBypagination(int currentPage, int pageSize)
        {
            return Ok(await _organizationsServices.GetOrganizationBypagination(currentPage, pageSize));
        }

        /// <summary>
        /// Get Organizations by name Order by Name ASC
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of organization has name likely with search key</returns>
        [HttpGet("search/{search}/orderASCByName")]
        public async Task<IActionResult> SearchOrangizationsByNameASCByName(string search)
        {
            return Ok(await _organizationsServices.SearchOrganizationsByNameASCByName(search));
        }

        /// <summary>
        /// Get Organizations by name Order by Name ASC
        /// </summary>
        /// <param name="search"></param>
        /// <returns>List of organization has name likely with search key</returns>
        [HttpGet("search/{search}/orderDESCByName")]
        public async Task<IActionResult> GetOrangizationsByNameDESCByName(string search)
        {
            return Ok(await _organizationsServices.SearchOrganizationsByNameDESCByName(search));
        }

        /// <summary>
        /// Create new Organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when create a new organization</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrganization(CreateOrganizationReq request)
        {
            return Ok(await _organizationsServices.CreateOrganization(request));
        }

        /// <summary>
        /// Update data of a organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when update data of a organization</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrganization(UpdateOrganizationReq request)
        {
            return Ok(await _organizationsServices.UpdateOrganization(request));
        }

    }
}
