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

        public async Task<UpdateCustomerRes> UpdateCustomer(UpdateCustomerReq request)
        {
            return await _customerRepository.UpdateCustomer(request);
        }

        public async Task<Customer> GetCustomerById(string customerId)
        {
            return await _customerRepository.GetCustomerById(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _customerRepository.GetAllCustomer();
        }

        public async Task<IEnumerable<Customer>> SearchByNameOrIdentityNumberAscByFirstName(string keyWord)
        {
            return await _customerRepository.SearchByNameOrIdentityNumberAscByFirstName(keyWord);
        }
    }
}
