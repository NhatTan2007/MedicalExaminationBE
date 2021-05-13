using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerServices;

        public CustomerController(ICustomerService customerServices)
        {
            _customerServices = customerServices;
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet("")]
        //[Authorize]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await _customerServices.GetAllCustomer());
        }

        /// <summary>
        /// GetCustomerBypagination
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("currentPage/{currentPage}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetCustomerBypagination(int currentPage, int pageSize)
        {
            return Ok(await _customerServices.GetCustomerBypagination(currentPage, pageSize));
        }

        /// <summary>
        /// Get customer by customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Specific customer</returns>
        [HttpGet("{customerId}")]
        //[Authorize]
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
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerReq request)
        {
            return Ok(await _customerServices.UpdateCustomer(request));
        }

        /// <summary>
        /// Search a customer by name or identity number
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List or a customer</returns>
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> SearchByNameOrIdentityNumberAscByFirstName(string keyword)
        {
            return Ok(await _customerServices.SearchByNameOrIdentityNumberAscByFirstName(keyword));
        }
        /// <summary>
        /// Get a customer by Identity Number
        /// </summary>
        /// <param name="identityNumber"></param>
        /// <returns>A customer</returns>
        [HttpGet("identityNumber/{identityNumber}")]
        public async Task<IActionResult> GetCustomerByIdentityNumber(string identityNumber)
        {
            return Ok(await _customerServices.GetCustomerByIdentityNumber(identityNumber));
        }
    }
}
