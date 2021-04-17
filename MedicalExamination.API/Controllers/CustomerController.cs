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
        [HttpGet("api/customers/gets")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _customerServices.GetS());
        }
        [HttpGet("api/customers/get/{customerId}")]
        public async Task<IActionResult> GetCustomertById(string customerId)
        {
            return Ok(await _customerServices.GetCustomerById(customerId));
        }

        [HttpPost("api/customer/create")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerReq request)
        {
            return Ok(await _customerServices.CreateCustomer(request));
        }
        [HttpPut("api/customer/edit/")]

        public async Task<IActionResult> EditProduct(EditCustomerReq request)
        {
            return Ok(await _customerServices.EditProduct(request));
        }


    }
}
