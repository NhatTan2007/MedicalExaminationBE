using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.OrganizationRes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Interface
{
   public interface IOrganizationsRepository
    {
        Task<IEnumerable<Organization>> GetAllOrganizations();
        Task<Organization> GetOrganizationById(string orangizationId);
        Task<CreateOrganizationRes> CreateOrganization(CreateOrganizationReq request);
        Task<UpdateOrganizationRes> UpdateOrganization(UpdateOrganizationReq request);
        Task<IEnumerable<Organization>> SearchOrganizationsByNameASCByName(string orangizationName);
        Task<IEnumerable<Organization>> SearchOrganizationsByNameDESCByName(string orangizationName);
        
    }
}
