using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.CustomerOrganization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class CustomerOrganizationController: BaseApiController
    {
        private readonly ICustomerOrganizationService _customerOrganizationServices;

        public CustomerOrganizationController(ICustomerOrganizationService customerOrganizationServices)
        {
            _customerOrganizationServices = customerOrganizationServices;
        }

        /// <summary>
        /// Create new customer organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response of create a new customer organization</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomerOrganization(CreateCustomerOrganizationReq request)
        {
            return Ok(await _customerOrganizationServices.CreateCustomerOrganization(request));
        }

        /// <summary>
        /// Update data of a customer organization
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response update data of a customer organization</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomerOrganization(UpdateCustomerOrganizationReq request)
        {
            return Ok(await _customerOrganizationServices.UpdateCustomerOrganization(request));
        }

        /// <summary>
        /// Get Customer Organization By OrganizationId
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>List of Customer Organization</returns>
        [HttpGet("organization/{organizationId}")]
        public async Task<IActionResult> GetCustomerOrganizationByOrganizationId(string organizationId)
        {
            return Ok(await _customerOrganizationServices.GetCustomerOrganizationByOrganizationId(organizationId));
        }

        /// <summary>
        /// Get Customer Organization By OrganizationId And Customer id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="customerId"></param>
        /// <returns>A Customer Organization</returns>
        [HttpGet("organization/{organizationId}/customer/{customerId}")]
        public async Task<IActionResult> GetCustomerOrganizationByCustomerIdAndOrganizationId(string organizationId, string customerId)
        {
            return Ok(await _customerOrganizationServices.GetCustomerOrganizationByCustomerIdAndOrganizationId(organizationId, customerId));
        }
    }
}
