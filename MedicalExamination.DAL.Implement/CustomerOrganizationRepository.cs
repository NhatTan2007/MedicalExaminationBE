using AutoMapper.Configuration;
using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.CustomerOrganization;
using MedicalExamination.Domain.Responses.CustomerOrganization;
using MedicalExamination.Domain.Responses.Customers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
//using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MedicalExamination.DAL.Implement
{
    public class CustomerOrganizationRepository : BaseRepository, ICustomerOrganizationRepository
    {
        public CustomerOrganizationRepository(Microsoft.Extensions.Configuration.IConfiguration config) : base(config)
        {

        }

        public async Task<CreateCustomerOrganizationRes> CreateCustomerOrganization(CreateCustomerOrganizationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CustomerId", request.CustomerId);
            parameters.Add(name: "@OrganizationId", request.OrganizationId);
            parameters.Add(name: "@IsActive", request.IsActive);
            parameters.Add(name: "@CustomerFirstName", request.CustomerFirstName);
            parameters.Add(name: "@CustomerLasNtame", request.CustomerLasNtame);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CreateCustomerOrganizationRes>(
                cnn: connection,
                sql: "sp_CreateCustomerOrganization",
                param: parameters,
                commandType:CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new CreateCustomerOrganizationRes();
                }
            }
        }

        public async Task<CustomerOrganization> GetCustomerOrganizationByCustomerIdAndOrganizationId(string organizationId, string customerId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerId", organizationId);
            parameters.Add("@OrganizationId", customerId);

            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CustomerOrganization>(
                                                cnn: connection,
                                                sql: "sp_GetCustomersOrganizationsByCustomerIdAndOrganizationId",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception ex)
                {
                    return new CustomerOrganization();
                }
            }
        }

        public async Task<IEnumerable<CustomerOrganization>> GetCustomerOrganizationByOrganizationId(string organizationId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", organizationId);
            using (var result = SqlMapper.QueryAsync<CustomerOrganization>(
                                                cnn: connection,
                                                sql: "sp_GetCustomersOrganizationsByOrganizationId",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<CustomerOrganization>();
                }
            }
        }

        public async Task<UpdateCustomerOrganizationRes> UpdateCustomerOrganization(UpdateCustomerOrganizationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CustomerId", request.CustomerId);
            parameters.Add(name: "@OrganizationId", request.OrganizationId);
            parameters.Add(name: "@IsActive", request.IsActive);
            parameters.Add(name: "@CustomerFirstName", request.CustomerFirstName);
            parameters.Add(name: "@CustomerLasNtame", request.CustomerLasNtame);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CustomerOrganization>(
                                                            cnn: connection,
                                                            sql: "sp_UpdateCustomerOrganization",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    UpdateCustomerOrganizationRes editRes = new UpdateCustomerOrganizationRes();
                    editRes.CustomerOrganization = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }
                catch (Exception)
                {
                    return new UpdateCustomerOrganizationRes();
                }
            }
        }
    }
}
