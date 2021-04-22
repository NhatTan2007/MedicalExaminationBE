using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.GroupMedicalExamination;
using MedicalExamination.Domain.Responses.GroupMedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace MedicalExamination.DAL.Implement
{
    public class GMExaminationRepository : BaseRepository , IGMExaminationRepository 
    {
        public GMExaminationRepository(IConfiguration config): base (config)
        {

        }

        public async Task<IEnumerable<GroupMedicalExamination>> GetAllGMExaminations()
        {
            using (var result = SqlMapper.QueryAsync<GroupMedicalExamination>(cnn: connection ,
                                                                                sql: "sp_GetAllGMExaminations",
                                                                                commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch
                {
                    return new List<GroupMedicalExamination>();
                }
            }

        }

        public async Task<GroupMedicalExamination> GetGMExaminationById(string GMExaminationId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GMExaminationId", GMExaminationId);

            using (var result = SqlMapper
                               .QueryFirstOrDefaultAsync<GroupMedicalExamination>(cnn:connection,
                                                                                  sql: "sp_GetGMExaminationById",
                                                                                  param:parameters,
                                                                                  commandType: CommandType.StoredProcedure))
            {
                try
                {
                    return await result;
                }
                catch (Exception)
                {
                    return new GroupMedicalExamination();
                }
            }
        }

        public async Task<CreateGMExaminationRes> CreateGMExamination(CreateGMExaminationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DateStart", request.DateStart);
            parameters.Add("@DateEnd", request.DateEnd);
            parameters.Add("@Advances", request.Advances);
            parameters.Add("@Discount", request.Discount);
            parameters.Add("@OrganizationId", request.OrganiationId);

            using (var result = SqlMapper
                            .QueryFirstOrDefaultAsync<CreateGMExaminationRes>(cnn: connection,
                                                                              sql: "sp_CreateGroupMedicalExamination",
                                                                              param: parameters,
                                                                             commandType:CommandType.StoredProcedure))

            try
            {
                    return await result;
            }
            catch (Exception)
            {

                    return new CreateGMExaminationRes();
            }
        }
        
        public async Task<UpdateGMExaminationRes> UpdateGMExamination(UpdateGMExaminationReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GMExaminationId", request.GMExaminationId);
            parameters.Add("@DateStart", request.DateStart);
            parameters.Add("@DateEnd", request.DateEnd);
            parameters.Add("@Advances", request.Advances);
            parameters.Add("@Discount", request.Discount);
            parameters.Add("@OrganizationId", request.OrganiationId);
            parameters.Add(name: "@Message", "", DbType.String, ParameterDirection.Output);

            using (var result = SqlMapper.QueryFirstOrDefaultAsync<GroupMedicalExamination>(cnn: connection,
                                                                                             sql: "sp_UpdateGroupMedicalExamination",
                                                                                             param: parameters,
                                                                                             commandType: CommandType.StoredProcedure))

                
                {
                    UpdateGMExaminationRes editRes = new UpdateGMExaminationRes();
                    editRes.GMExamination = await result;
                    editRes.Message = parameters.Get<string>("@Message");
                    return editRes;
                }
               
        }

        public async Task<IEnumerable<GroupMedicalExamination>> GetGMExaminationByOrganizationId(string OrganizationId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@OrganizationId", OrganizationId);

            using(var result = SqlMapper.QueryAsync<GroupMedicalExamination>(cnn: connection,
                                                                            sql: "sp_GetGMExaminationByOrganizationId",
                                                                            param: parameters,
                                                                            commandType: CommandType.StoredProcedure))

                try
                {
                    return await result;
                }
                catch (Exception)
                {

                    return new List<GroupMedicalExamination>();
                }

        }
    }
}
