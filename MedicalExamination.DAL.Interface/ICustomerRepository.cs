using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Customers;
using MedicalExamination.Domain.Responses.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(string customerId);
        Task<CreateCustomerRes> CreateCustomer(CreateCustomerReq request);
        Task<UpdateCustomerRes> UpdateCustomer(UpdateCustomerReq request);
        Task<IEnumerable<Customer>> SearchByNameOrIdentityNumberAscByFirstName(string keyWord);
    }
}
