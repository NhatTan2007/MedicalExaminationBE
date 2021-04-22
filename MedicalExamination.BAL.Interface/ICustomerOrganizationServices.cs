using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.CustomerOrganization;
using MedicalExamination.Domain.Responses.CustomerOrganization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface ICustomerOrganizationServices
    {
        Task<CreateCustomerOrganizationRes> CreateCustomerOrganization(CreateCustomerOrganizationReq request);
        Task<UpdateCustomerOrganizationRes> UpdateCustomerOrganization(UpdateCustomerOrganizationReq request);
        Task<IEnumerable<CustomerOrganization>> GetCustomerOrganizationByOrganizationId(string organizationId);
        Task<CustomerOrganization> GetCustomerOrganizationByCustomerIdAndOrganizationId(string organizationId, string customerId);
    }
}
