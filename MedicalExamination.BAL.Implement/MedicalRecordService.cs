using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.MedicalRecord;
using MedicalExamination.Domain.Responses.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }
        public Task<CreateMedicalRecordRes> CreateMedicalRecord(CreateMedicalRecordReq request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords()
        {
            return await _medicalRecordRepository.GetAllInactiveMedicalRecords();
        }

        public async Task<MedicalRecord> GetMedicalRecordById(string medicalRecordId)
        {
            return await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> SearchMedicalRecordByNameOrIdActiveNotFinishedExamination(string searchKey)
        {
            return await _medicalRecordRepository.SearchMedicalRecordByNameOrIdActiveNotFinishedExamination(searchKey);
        }

        public async Task<UpdateMedicalRecordRes> UpdateMedicalRecord(UpdateMedicalRecordReq request)
        {
            throw new NotImplementedException();
        }
    }
}
