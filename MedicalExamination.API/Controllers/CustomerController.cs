using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await _customerServices.GetAllCustomer());
        }

        /// <summary>
        /// Get customer by customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Specific customer</returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomertById(string customerId)
        {
            return Ok(await _customerServices.GetCustomerById(customerId));
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when create a new customer</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerReq request)
        {
            return Ok(await _customerServices.CreateCustomer(request));
        }

        /// <summary>
        /// Update information of specific customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response when update customer information</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomerd(UpdateCustomerReq request)
        {
            return Ok(await _customerServices.UpdateCustomer(request));
        }

        /// <summary>
        /// Update information of specific customer
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Response when update customer information</returns>
        [HttpGet("search/{keyWord}")]
        public async Task<IActionResult> SearchByNameOrIdentityNumberAscByFirstName(string keyword)
        {
            return Ok(await _customerServices.SearchByNameOrIdentityNumberAscByFirstName(keyword));
        }
    }
}
