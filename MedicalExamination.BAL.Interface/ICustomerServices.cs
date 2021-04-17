using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Customers;
using MedicalExamination.Domain.Responses.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customers>> GetS();
        Task<Customers> GetCustomerById(string customerId);
        Task<CreateCustomerRes> CreateCustomer(CreateCustomerReq request);
        Task<EditCustomerRes> EditProduct(EditCustomerReq request);
    }
}
