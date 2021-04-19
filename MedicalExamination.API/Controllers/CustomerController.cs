using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.Customers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("api/customer/GetCustomers")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await _customerServices.GetAllCustomer());
        }


        [HttpGet("api/customer/get/{customerId}")]
        public async Task<IActionResult> GetCustomertById(string customerId)
        {
            return Ok(await _customerServices.GetCustomerById(customerId));
        }

        [HttpPost("api/customer/create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerReq request)
        {
            return Ok(await _customerServices.CreateCustomer(request));
        }


        [HttpPut("api/customer/Update/")]
        public async Task<IActionResult> UpdateCustomerd(UpdateCustomerReq request)
        {
            return Ok(await _customerServices.UpdateCustomer(request));
        }

        [HttpPut("api/customer/Search/{keyWord}")]
        public async Task<IActionResult> SearchByNameOrIdentityNumberAscByFirstName(string keyWord)
        {
            return Ok(await _customerServices.SearchByNameOrIdentityNumberAscByFirstName(keyWord));
        }



    }
}
