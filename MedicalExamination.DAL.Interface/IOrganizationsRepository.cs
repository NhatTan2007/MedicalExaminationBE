using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.Organization;
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
        Task<QuerryOrganizationRes> GetOrganizationBypagination(int currentPage, int pageSize);
        Task<Organization> GetOrganizationById(string orangizationId);
        Task<CreateOrganizationRes> CreateOrganization(CreateOrganizationReq request);
        Task<UpdateOrganizationRes> UpdateOrganization(UpdateOrganizationReq request);
        Task<IEnumerable<Organization>> SearchOrganizationsByNameASCByName(string search);
        Task<IEnumerable<Organization>> SearchOrganizationsByNameDESCByName(string search);
        Task<QuerryOrganizationRes> SearchByOrganizationPagination(string keyword, int currentPage, int pageSize);

    }
}
