using MedicalExamination.Domain.Entities;
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
        Task<UpdateMedicalRecordRes> UpdateMedicalRecord(UpdateMedicalRecordReq request);
        Task<MedicalRecord> GetMedicalRecordById(string medicalRecordId);
        Task<IEnumerable<MedicalRecordViewRes>> SearchMedicalRecordByNameOrIdActiveNotFinishedExamination(string searchKey);
        Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords();
    }
}
