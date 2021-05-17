using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.MedicalService;
using MedicalExamination.Domain.Responses.MedicalService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
    public class MedicalServiceRepository : BaseRepository, IMedicalServiceRepository
    {

        public MedicalServiceRepository(IConfiguration config) : base(config)
        {

        }

        public async Task<CreateMedicalServiceRes> CreateMedicalService(CreateMedicalServiceReq request)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@MServiceName", request.MServiceName);
            parameters.Add(name: "@Price", request.Price);
            parameters.Add(name: "@IsActive", request.IsActive);
            parameters.Add(name: "@DepartmentId", request.DepartmentId);

            using var result = SqlMapper.QueryFirstOrDefaultAsync<CreateMedicalServiceRes>(
                                                            cnn: connection,
                                                            sql: "sp_CreateMedicalService",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure);
            try
            {
                return await result;
            }
            catch (Exception)
            {
                return new CreateMedicalServiceRes();
            }
        }

        public async Task<IEnumerable<MedicalService>> GetActiveMedicalServices()
        {
            DynamicParameters parameters = new DynamicParameters();
            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                                cnn: connection,
                                                sql: "sp_GetActiveMedicalServices",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                return await result;
            }
        }

        public async Task<QuerryMSerciceRes> GetActiveMedicalServicesBypagination(int currentPage, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CurrentPage", currentPage);
            parameters.Add(name: "@PageSize", pageSize);
            parameters.Add(name: "@TotalMedicalSevices", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                              cnn: connection,
                                              sql: "sp_GetActiveMedicalServicesByPagination",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    QuerryMSerciceRes querryResult = new QuerryMSerciceRes();
                    querryResult.MedicalService = await result;
                    querryResult.TotalMedicalSevices = parameters.Get<int>("@TotalMedicalSevices");
                    return querryResult;
                }
                catch (Exception ex)
                {
                    return new QuerryMSerciceRes();
                }
        }

        public async Task<IEnumerable<MedicalService>> GetMedicalServiceByDepartmentId(string departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                                cnn: connection,
                                                sql: "sp_GetMedicalServiceByDepartmentId",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new List<MedicalService>();
                }
            }
        }

        public async Task<MedicalService> GetMedicalServiceByMedicalServiceId(string medicalServiceId)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MedicalServiceId", medicalServiceId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<MedicalService>(
                                                cnn: connection,
                                                sql: "sp_GetMedicalServiceByMedicalServiceId",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception ex)
                {
                    return new MedicalService();
                }
            }
        }

        public async Task<IEnumerable<MedicalService>> GetMedicalServices()
        {
            DynamicParameters parameters = new DynamicParameters();
            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                                cnn: connection,
                                                sql: "sp_GetAllMedicalServices",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure))
            {
                    return await result;
            }
        }

        public async Task<QuerryMSerciceRes> GetMedicalServicesBypagination(int currentPage, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@CurrentPage", currentPage);
            parameters.Add(name: "@PageSize", pageSize);
            parameters.Add(name: "@TotalMedicalSevices", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                              cnn: connection,
                                              sql: "sp_PaginationByMedicalSevices",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    QuerryMSerciceRes querryResult = new QuerryMSerciceRes();
                    querryResult.MedicalService = await result;
                    querryResult.TotalMedicalSevices = parameters.Get<int>("@TotalMedicalSevices");
                    return querryResult;
                }
                catch (Exception ex)
                {
                    return new QuerryMSerciceRes();
                }
        }

        public async Task<QuerryMSerciceRes> SearchByNameMServicePagination(string keyword, int currentPage, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@SearchKey", keyword);
            parameters.Add(name: "@CurrentPage", currentPage);
            parameters.Add(name: "@PageSize", pageSize);
            parameters.Add(name: "@TotalMedicalSevices", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var result = SqlMapper.QueryAsync<MedicalService>(
                                              cnn: connection,
                                              sql: "sp_SearchByMedicalSevicesPagination",
                                              param: parameters,
                                              commandType: CommandType.StoredProcedure))
                try
                {
                    QuerryMSerciceRes querryResult = new QuerryMSerciceRes();
                    querryResult.MedicalService = await result;
                    querryResult.TotalMedicalSevices = parameters.Get<int>("@TotalMedicalSevices");
                    return querryResult;
                }
                catch (Exception)
                {
                    return new QuerryMSerciceRes();
                }
        }

        public async Task<UpdateMedicalServiceRes> UpdateMedicalService(UpdateMedicalServiceReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@MserviceId", request.MServiceId);
            parameters.Add(name: "@MServiceName", request.MServiceName);
            parameters.Add(name: "@Price", request.Price);
            parameters.Add(name: "@IsActive", request.IsActive);
            parameters.Add(name: "@DepartmentId", request.DepartmentId);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<MedicalService>(
                                                            cnn: connection,
                                                            sql: "sp_UpdateMedicalService",
                                                            param: parameters,
                                                            commandType: CommandType.StoredProcedure))
            {
                try
                {
                    UpdateMedicalServiceRes editRes = new UpdateMedicalServiceRes();
                    editRes.MedicalService = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }
                catch (Exception)
                {
                    return new UpdateMedicalServiceRes();
                }
            }
        }
    }
}
