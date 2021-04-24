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
        private readonly ICustomerOrganizationServices _customerOrganizationServices;

        public CustomerOrganizationController(ICustomerOrganizationServices customerOrganizationServices)
        {
            _customerOrganizationServices = customerOrganizationServices;
        }


        [HttpPost("api/customerOrganization/create")]
        public async Task<IActionResult> CreateCustomerOrganization(CreateCustomerOrganizationReq request)
        {
            return Ok(await _customerOrganizationServices.CreateCustomerOrganization(request));
        }


        [HttpPut("api/customerOrganization/update/")]
        public async Task<IActionResult> UpdateCustomerOrganization(UpdateCustomerOrganizationReq request)
        {
            return Ok(await _customerOrganizationServices.UpdateCustomerOrganization(request));
        }


        [HttpGet("api/CustomerOrganization/get/{organizationId}")]
        public async Task<IActionResult> GetCustomerOrganizationByOrganizationId(string organizationId)
        {
            return Ok(await _customerOrganizationServices.GetCustomerOrganizationByOrganizationId(organizationId));
        }

        [HttpGet("api/CustomerOrganization/get/{organizationId}/{customerId}")]
        public async Task<IActionResult> GetCustomerOrganizationByCustomerIdAndOrganizationId(string organizationId, string customerId)
        {
            return Ok(await _customerOrganizationServices.GetCustomerOrganizationByCustomerIdAndOrganizationId(organizationId, customerId));
        }
    }
}
