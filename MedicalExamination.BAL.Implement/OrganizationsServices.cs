using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.Organization;
using MedicalExamination.Domain.Responses.OrganizationRes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class OrganizationsServices : IOrganizationsServices
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        public OrganizationsServices(IOrganizationsRepository organizationsRepository)
        {
            _organizationsRepository = organizationsRepository;
        }

        public async Task<CreateOrganizationRes> CreateOrganization(CreateOrganizationReq request)
        {
            return await _organizationsRepository.CreateOrganization(request);
        }

        public async Task<UpdateOrganizationRes> EditOrganization(UpdateOrganizationReq request)
        {
            return await _organizationsRepository.EditOrganization(request);
        }

        public async Task<IEnumerable<Organization>> GetAllOrganization()
        {
            return await _organizationsRepository.GetAllOrganization();
        }

        public async Task<Organization> GetOrganizationById(string orangizationId)
        {
            return await _organizationsRepository.GetOrganizationById(orangizationId);
        }
      
        public async Task<IEnumerable<Organization>> GetOrganizationsByNameASCByName(string orangizationName)
        {
            return await _organizationsRepository.GetOrganizationsByNameASCByName(orangizationName);
        }

        public async Task<IEnumerable<Organization>> GetOrganizationsByNameDESCByName(string orangizationName)
        {
            return await _organizationsRepository.GetOrganizationsByNameDESCByName(orangizationName);
        }
    }
}
