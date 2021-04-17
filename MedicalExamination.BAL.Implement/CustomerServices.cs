using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Customers;
using MedicalExamination.Domain.Responses.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<CreateCustomerRes> CreateCustomer(CreateCustomerReq request)
        {
            return await _customerRepository.CreateCustomer(request);
        }

        public async Task<EditCustomerRes> EditProduct(EditCustomerReq request)
        {
            return await _customerRepository.EditProduct(request);
        }

        public async Task<Customers> GetCustomerById(string customerId)
        {
            return await _customerRepository.GetCustomerById(customerId);
        }

        public async Task<IEnumerable<Customers>> GetS()
        {
            return await _customerRepository.GetS();
        }
    }
}
