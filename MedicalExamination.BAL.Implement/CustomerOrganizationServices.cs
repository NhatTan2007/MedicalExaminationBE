using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.CustomerOrganization;
using MedicalExamination.Domain.Responses.CustomerOrganization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
     public class CustomerOrganizationServices : ICustomerOrganizationServices
    {
        private readonly ICustomerOrganizationRepository _customerOrganizationRepository;

        public CustomerOrganizationServices(ICustomerOrganizationRepository customerOrganizationRepository)
        {
            _customerOrganizationRepository = customerOrganizationRepository;
        }

        public async Task<CreateCustomerOrganizationRes> CreateCustomerOrganization(CreateCustomerOrganizationReq request)
        {
            return await _customerOrganizationRepository.CreateCustomerOrganization(request);
        }

        public async Task<CustomerOrganization> GetCustomerOrganizationByCustomerIdAndOrganizationId(string organizationId, string customerId)
        {
            return await _customerOrganizationRepository.GetCustomerOrganizationByCustomerIdAndOrganizationId(organizationId, customerId);
        }

        public async Task<IEnumerable<CustomerOrganization>> GetCustomerOrganizationByOrganizationId(string organizationId)
        {
            return await _customerOrganizationRepository.GetCustomerOrganizationByOrganizationId(organizationId);
        }

        public async Task<UpdateCustomerOrganizationRes> UpdateCustomerOrganization(UpdateCustomerOrganizationReq request)
        {
            return await _customerOrganizationRepository.UpdateCustomerOrganization(request);
        }
    }
}
