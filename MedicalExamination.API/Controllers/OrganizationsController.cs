using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.OrganizationRes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationsServices _organizationsServices;

        public OrganizationsController(IOrganizationsServices organizationsServices)
        {
            _organizationsServices = organizationsServices;
        }

        /// <summary>
        /// Get all Organizations 
        /// </summary>
        /// <returns>List all Organizations</returns>
        [HttpGet("api/organizations/GetsAllOrganizations")]
        public async Task<IActionResult> GetAllOrganizations()
        {
            return Ok(await _organizationsServices.GetAllOrganizations());
        }

        /// <summary>
        /// Get Organization by Id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/Organizations/GetOrganization/{organizationId}")]
        public async Task<IActionResult> GetProductById(string organizationId)
        {
            return Ok(await _organizationsServices.GetOrganizationById(organizationId));
        }

        /// <summary>
        /// Get Organizations by name Order ASC
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/Organizations/GetOrganizationsByNameASC/{organizationName}")]
        public async Task<IActionResult> SearchOrangizationsByNameASCByName(string organizationName)
        {
            return Ok(await _organizationsServices.SearchOrganizationsByNameASCByName(organizationName));
        }

        /// <summary>
        /// Get Organizations by name Order ASC
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/Organizations/SearchOrganizationsByNameDESC/{organizationName}")]
        public async Task<IActionResult> GetOrangizationsByNameDESCByName(string organizationName)
        {
            return Ok(await _organizationsServices.SearchOrganizationsByNameDESCByName(organizationName));
        }

        /// <summary>
        /// Create new Organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New Organization</returns>
        [HttpPost("api/Organizations/CreateOrganization")]
        public async Task<IActionResult> CreateProduct(CreateOrganizationReq request)
        {
            return Ok(await _organizationsServices.CreateOrganization(request));
        }

        /// <summary>
        /// Edit new Organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Organization updated</returns>
        [HttpPut("api/Organizations/UpdateOrganization")]
        public async Task<IActionResult> UpdateOrangization(UpdateOrganizationReq request)
        {
            return Ok(await _organizationsServices.UpdateOrganization(request));
        }

    }
}
