using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Models.MedicalRecord;
using MedicalExamination.Domain.Requests.MedicalRecord;
using MedicalExamination.Domain.Responses.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IMedicalRecordService
    {
        Task<CreateMedicalRecordRes> CreateMedicalRecord(CreateMedicalRecordReq request);
        Task<MedicalRecordModel> GetMedicalRecordById(string medicalRecordId);
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByNameOrIdActiveNotFinishedExamination();
        Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords();
        Task<UpdateMedicalRecordRes> PaidMedicalRecord(string medicalRecordId);
        Task<UpdateMedicalRecordRes> ActiveMedicalRecord(string medicalRecordId);
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByCustomerId(string customerId);
    }
}
