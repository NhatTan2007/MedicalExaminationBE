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

        [HttpGet("api/organizations/Gets")]
        public async Task<IActionResult> getallorganization()
        {
            return Ok(await _organizationsServices.GetAllOrganization());
        }

        /// <summary>
        /// Get Organization by Id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/organizations/getorganization/{organizationId}")]
        public async Task<IActionResult> GetProductById(string organizationId)
        {
            return Ok(await _organizationsServices.GetOrganizationById(organizationId));
        }

        /// <summary>
        /// Get Organizations by name Order ASC
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/organizations/getOrganizationsByNameASC/{organizationName}")]
        public async Task<IActionResult> GetOrangizationsByNameASCByName(string organizationName)
        {
            return Ok(await _organizationsServices.GetOrganizationsByNameASCByName(organizationName));
        }

        /// <summary>
        /// Get Organizations by name Order ASC
        /// </summary>
        /// <param name="organizationName"></param>
        /// <returns>Specific Product has id want to find</returns>
        [HttpGet("api/organizations/getOrganizationsByNameDESC/{organizationName}")]
        public async Task<IActionResult> GetOrangizationsByNameDESCByName(string organizationName)
        {
            return Ok(await _organizationsServices.GetOrganizationsByNameDESCByName(organizationName));
        }

        /// <summary>
        /// Create new Organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>New Organization</returns>
        [HttpPost("api/organizations/createorganization")]
        public async Task<IActionResult> CreateProduct(CreateOrganizationReq request)
        {
            return Ok(await _organizationsServices.CreateOrganization(request));
        }

        /// <summary>
        /// Edit new Organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Organization updated</returns>
        [HttpPost("api/organizations/editorganization")]
        public async Task<IActionResult> EditOrangization(UpdateOrganizationReq request)
        {
            return Ok(await _organizationsServices.EditOrganization(request));
        }

    }
}
