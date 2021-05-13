using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Responses.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Interface
{
    public interface IMedicalRecordRepository
    {
        Task<CreateMedicalRecordRes> CreateMedicalRecord(MedicalRecord medicalRecord);
        Task<UpdateMedicalRecordRes> UpdateMedicalRecord(MedicalRecord medicalRecord);
        Task<MedicalRecord> GetMedicalRecordById(string medicalRecordId);
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByNameOrIdActiveNotFinishedExamination();
        Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords();
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByCustomerId(string customerId);
    }
}
