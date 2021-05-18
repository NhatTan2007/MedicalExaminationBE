using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Models.MedicalRecord;
using MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms;
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
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByNameOrIdActiveFinishedExamination();
        Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords();
        Task<UpdateMedicalRecordRes> PaidMedicalRecord(string medicalRecordId);
        Task<UpdateMedicalRecordRes> ActiveMedicalRecord(string medicalRecordId);
        Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByCustomerId(string customerId);

        //Update result
        Task<UpdateMedicalRecordRes> UpdateDermatologyExamination(DermatologyExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateNeurologyExamination(NeurologyExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateInternalMedicineExamination(InternalMedicineExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateObstetricsAndGynecologyExamination(ObstetricsAndGynecologyExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateOphthalmologyExamination(OphthalmologyExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateOralAndMaxillofacialExamination(OralAndMaxillofacialExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateOtorhinolaryngologyExamination(OtorhinolaryngologyExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdatePhysicalExamination(PhysicalExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateSurgeryExamination(SurgeryExamination result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateBloodTests(BloodTests result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateClinicalUrineTests(ClinicalUrineTests result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateAbdominalUltrasound(AbdominalUltrasound result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateBreastUltrasound(BreastUltrasound result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateCardiacUltrasoundProbes(CardiacUltrasoundProbes result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateThyroidUltrasound(ThyroidUltrasound result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateChestXray(ChestXray result, string mRecordId);
        Task<UpdateMedicalRecordRes> UpdateFinalExaminationResult(FinalExaminationResult result, string mRecordId);
    }
}
