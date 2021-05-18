using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Customers;
using MedicalExamination.Domain.Responses.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<QueryCustomerRes> GetCustomerBypagination(int currentPage, int pageSize);
        Task<Customer> GetCustomerById(string customerId);
        Task<Customer> GetCustomerByIdentityNumber(string identityNumber);
        Task<CreateCustomerRes> CreateCustomer(CreateCustomerReq request);
        Task<UpdateCustomerRes> UpdateCustomer(UpdateCustomerReq request);
        Task<IEnumerable<Customer>> SearchByNameOrIdentityNumberAscByFirstName(string keyword);
        Task<QueryCustomerRes> SearchByNameOrIdentityNumberPagination(string keyword, int currentPage, int pageSize);


    }
}
