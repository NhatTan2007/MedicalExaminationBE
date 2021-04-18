using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.Organization;
using MedicalExamination.Domain.Responses.OrganizationRes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
   public interface IOrganizationsServices
    {
        Task<IEnumerable<Organization>> GetAllOrganization();
        Task<Organization> GetOrganizationById(string orangizationId);
        Task<CreateOrganizationRes> CreateOrganization(CreateOrganizationReq request);
        Task<UpdateOrganizationRes> EditOrganization(UpdateOrganizationReq request);
        Task<Organization> GetOrganizationByName(string orangizationName);
        Task<IEnumerable<Organization>> GetOrganizationsByNameASCByName(string orangizationName);
        Task<IEnumerable<Organization>> GetOrganizationsByNameDESCByName(string orangizationName);
    }
}
