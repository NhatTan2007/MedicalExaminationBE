using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Department;
using MedicalExamination.Domain.Responses.Department;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(IConfiguration config) : base (config)
        {

        }

        public async Task<Department> GetDepartmentById(string departmentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);

            using (var result = SqlMapper.QueryFirstOrDefaultAsync<Department>(
                                               cnn: connection,
                                               sql: "sp_GetDepartmentById",
                                               param: parameters,
                                               commandType: CommandType.StoredProcedure))

                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new Department();

                }
        }


        public async Task<CreateDepartmentRes> CreateDepartment(CreateDepartmentReq request)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentName", request.DepartmentName);
                parameters.Add("@IsActive", request.IsActive);
                            
                using (var result = SqlMapper
                        .QueryFirstOrDefaultAsync<CreateDepartmentRes>(cnn: connection,
                                                                        sql: "sp_CreateDepartment",
                                                                        param: parameters,
                                                                        commandType: CommandType.StoredProcedure))

                    try
                    {
                        return await result;
                    }
                    catch (Exception)
                    {

                        return new CreateDepartmentRes();
                    }           
        }

        public async Task<UpdateDepartmentRes> UpdateDepartment(UpdateDepartmentReq request)
        {
          
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DepartmentId", request.DepartmentId);
                parameters.Add("@DepartmentName", request.DepartmentName);
                parameters.Add("@IsActive", request.IsActive);              
                parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);

                using (var result = SqlMapper
                                    .QueryFirstOrDefaultAsync<Department>(cnn: connection,
                                                                          sql: "sp_UpdateDepartment",
                                                                          param: parameters,
                                                                          commandType: CommandType.StoredProcedure))


                {
                    UpdateDepartmentRes editRes = new UpdateDepartmentRes();
                    editRes.Department = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }           

        }
    }
}
