using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Responses.Organization;
using MedicalExamination.Domain.Responses.OrganizationRes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
   public class OrganizationsRepository:BaseRepository , IOrganizationsRepository 
    {
        public OrganizationsRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<CreateOrganizationRes> CreateOrganization(CreateOrganizationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@OrganizationName", request.OrganizationName);
            parameters.Add(name: "@OrganizationPhoneNumber", request.OrganizationPhoneNumber);
            parameters.Add(name: "@OrganizationEmail", request.OrganizationEmail);
            parameters.Add(name: "@OrganizationAddress", request.OrganizationAddress);
            parameters.Add(name: "@PesonContact", request.PersonContact);
            parameters.Add(name: "@PhoneContact", request.PhoneContact);
            parameters.Add(name: "@EmailContact", request.EmailContact);
            
            using var result = SqlMapper.QueryFirstOrDefaultAsync<CreateOrganizationRes>(
                                                            cnn: connection,
                                                            sql: "sp_CreateOrganization",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);
            try
            {
                return await result;
            }
            catch (Exception)
            {
                return new CreateOrganizationRes();
            }
        }

      public async Task<UpdateOrganizationRes> UpdateOrganization(UpdateOrganizationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@OrganizationId", request.OrganizationId);
            parameters.Add(name: "@OrganizationName", request.OrganizationName);
            parameters.Add(name: "@OrganizationPhoneNumber", request.OrganizationPhoneNumber);
            parameters.Add(name: "@OrganizationEmail", request.OrganizationEmail);
            parameters.Add(name: "@OrganizationAddress", request.OrganizationAddress);
            parameters.Add(name: "@PesonContact", request.PersonContact);
            parameters.Add(name: "@PhoneContact", request.PhoneContact);
            parameters.Add(name: "@EmailContact", request.EmailContact);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Organization>(
                                                            cnn: connection,
                                                            sql: "sp_UpdateOrganization",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                    UpdateOrganizationRes editRes = new UpdateOrganizationRes();
                    editRes.Organization = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
            }
        }


        public async Task<IEnumerable<Organization>> GetAllOrganizations()
        {
            using (var result = SqlMapper.QueryAsync<Organization>(cnn: connection,
                                                                   sql: "sp_GetAllOrganization",
                                                                   commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch
                {
                    return new List<Organization>();
                }
            }                         
        }

        public async Task<Organization> GetOrganizationById(string orangizationId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", orangizationId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Organization>(
                                               cnn: connection,
                                               sql: "sp_SearchOrganizationsById",
                                               param: parameters,
                                               commandType: CommandType.StoredProcedure))

            try
            {
                    return await result;
            }
            catch (Exception)
            {
                    return new Organization();
                
            }

        }
     
        public async Task<IEnumerable<Organization>> SearchOrganizationsByNameASCByName(string search)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@Search", search);

            using (var result = SqlMapper.QueryAsync<Organization>(
                                              cnn: connection,
                                              sql: "sp_SearchOrganizationsByNameASCByName",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
            try
            {
                return await result;
            }
            catch (Exception)
            {
                   return new List<Organization>();
            }

        }

        public async Task<IEnumerable<Organization>> SearchOrganizationsByNameDESCByName(string search)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@Search", search);

            using (var result = SqlMapper.QueryAsync<Organization>(
                                              cnn: connection,
                                              sql: "sp_SearchOrganizationsByNameDESCByName",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<Organization>();
                }

        }

        public async Task<QueryOrganizationRes> GetOrganizationBypagination(int currentPage, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CurrentPage", currentPage);
            parameters.Add(name: "@PageSize", pageSize);
            parameters.Add(name: "@TotalOrganization", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var result = SqlMapper.QueryAsync<Organization>(

                                              cnn: connection,
                                              sql: "sp_PaginationByOrganization",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    QueryOrganizationRes querryResult = new QueryOrganizationRes();
                    querryResult.Organization = (IEnumerable<Organization>)await result;
                    querryResult.TotalOrganization = parameters.Get<int>("@TotalOrganization");
                    return querryResult;
                }
                catch (Exception ex)
                {
                    return new QueryOrganizationRes();
                }
        }

        public async Task<QueryOrganizationRes> SearchByOrganizationPagination(string keyword, int currentPage, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@SearchKey", keyword);
            parameters.Add(name: "@CurrentPage", currentPage);
            parameters.Add(name: "@PageSize", pageSize);
            parameters.Add(name: "@TotalOrganization", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var result = SqlMapper.QueryAsync<Organization>(
                                              cnn: connection,
                                              sql: "sp_SearchByOrganizationPagination",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    QueryOrganizationRes querryResult = new QueryOrganizationRes();
                    querryResult.Organization = await result;
                    querryResult.TotalOrganization = parameters.Get<int>("@TotalOrganization");
                    return querryResult;
                }
                catch (Exception)
                {
                    return new QueryOrganizationRes();
                }
        }
    }
}
