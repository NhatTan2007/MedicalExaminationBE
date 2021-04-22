using Dapper;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Responses.MedicalRecord;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
    public class MedicalRecordRepository : BaseRepository, IMedicalRecordRepository
    {
        public MedicalRecordRepository(IConfiguration config) : base (config)
        {

        }
        public async Task<CreateMedicalRecordRes> CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@MedicalRecordId", medicalRecord.MedicalRecordId);
            parameters.Add(name: "@Detail", medicalRecord.Details);
            parameters.Add(name: "@CreateDate", medicalRecord.CreateDate);
            parameters.Add(name: "@IsGroup", medicalRecord.IsGroup);
            parameters.Add(name: "@IsActive", medicalRecord.IsActive);
            parameters.Add(name: "@CustomerId", medicalRecord.CustomerId);
            parameters.Add(name: "@TotalAmount", medicalRecord.TotalAmount);
            parameters.Add(name: "@CustomerFirstName", medicalRecord.CustomerFirstName);
            parameters.Add(name: "@CustomerLastName", medicalRecord.CustomerLastName);
            parameters.Add(name: "@OrganizationId", medicalRecord.OrganizationId);
            parameters.Add(name: "@GMExaminationId", medicalRecord.GMExaminationId);
            parameters.Add(name: "@DateCompleted", medicalRecord.DateCompleted);
            parameters.Add(name: "@IsPaid", medicalRecord.IsPaid);
            parameters.Add(name: "@MedicalHistory", medicalRecord.MedicalHistory);
            parameters.Add(name: "@ReasonToExamination", medicalRecord.ReasonToExamination);
            parameters.Add(name: "@WasFinishedExamination", medicalRecord.WasFinishedExamination);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<CreateMedicalRecordRes>(
                cnn: connection,
                sql: "sp_CreateMedicalRecord",
                param: parameters,
                commandType: System.Data.CommandType.StoredProcedure))
            {
                return await result;
                
            };
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords()
        {
            DynamicParameters parameters = new DynamicParameters();
            using (var result = SqlMapper.QueryAsync<MedicalRecordViewRes>(
                cnn: connection,
                sql: "sp_GetAllInactiveMedicalRecords",
                param: parameters,
                commandType: System.Data.CommandType.StoredProcedure))
            {
                return await result;
            }
        }

        public async Task<MedicalRecord> GetMedicalRecordById(string medicalRecordId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@MedicalRecordId", medicalRecordId);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<MedicalRecord>(
                cnn: connection,
                sql: "sp_GetMedicalRecordByid",
                param: parameters,
                commandType: System.Data.CommandType.StoredProcedure))
            {
                return await result;
            }
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> SearchMedicalRecordByNameOrIdActiveNotFinishedExamination(string searchKey)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@SearchKey", searchKey);
            using (var result = SqlMapper.QueryAsync<MedicalRecordViewRes>(
                cnn: connection,
                sql: "sp_SearchMedicalRecordByNameOrIdActiveNotFinishedExamination",
                param: parameters,
                commandType: System.Data.CommandType.StoredProcedure))
            {
                return await result;
            }
        }

        public async Task<UpdateMedicalRecordRes> UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(name: "@MedicalRecordId", medicalRecord.MedicalRecordId);
            parameters.Add(name: "@Detail", medicalRecord.Details);
            parameters.Add(name: "@CreateDate", medicalRecord.CreateDate);
            parameters.Add(name: "@IsGroup", medicalRecord.IsGroup);
            parameters.Add(name: "@IsActive", medicalRecord.IsActive);
            parameters.Add(name: "@CustomerId", medicalRecord.CustomerId);
            parameters.Add(name: "@TotalAmount", medicalRecord.TotalAmount);
            parameters.Add(name: "@CustomerFirstName", medicalRecord.CustomerFirstName);
            parameters.Add(name: "@CustomerLastName", medicalRecord.CustomerLastName);
            parameters.Add(name: "@OrganizationId", medicalRecord.OrganizationId);
            parameters.Add(name: "@GMExaminationId", medicalRecord.GMExaminationId);
            parameters.Add(name: "@DateCompleted", medicalRecord.DateCompleted);
            parameters.Add(name: "@IsPaid", medicalRecord.IsPaid);
            parameters.Add(name: "@WasFinishedExamination", medicalRecord.WasFinishedExamination);
            parameters.Add(name: "@MedicalHistory", medicalRecord.MedicalHistory);
            parameters.Add(name: "@ReasonToExamination", medicalRecord.ReasonToExamination);
            parameters.Add(name: "@Message", "", System.Data.DbType.String, System.Data.ParameterDirection.Output);
            using (var result = SqlMapper.QueryFirstOrDefaultAsync<MedicalRecord>(
                cnn: connection,
                sql: "sp_CreateMedicalRecord",
                param: parameters,
                commandType: System.Data.CommandType.StoredProcedure))
            {
                UpdateMedicalRecordRes updateRes = new UpdateMedicalRecordRes();
                updateRes.Message = parameters.Get<string>("@Message");
                updateRes.MedicalRecord = await result;
                return updateRes;

            };
        }
    }
}
