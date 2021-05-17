using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using MedicalExamination.Domain.Models.MedicalRecord;
using MedicalExamination.Domain.Requests.MedicalRecord;
using MedicalExamination.Domain.Responses.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms;

namespace MedicalExamination.BAL.Implement
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IUserService _userService;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository,
                                    IUserService userService)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _userService = userService;
        }

        public async Task<UpdateMedicalRecordRes> ActiveMedicalRecord(string medicalRecordId)
        {
            MedicalRecord medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            if (medicalRecord != null)
            {
                medicalRecord.IsActive = true;
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
            }
            return new UpdateMedicalRecordRes() { Message = "Hồ sơ bệnh án không tồn tại" };
        }

        public async Task<CreateMedicalRecordRes> CreateMedicalRecord(CreateMedicalRecordReq request)
        {
            MedicalRecord newMedicalRecord = Helper.AutoDTO<CreateMedicalRecordReq, MedicalRecord>(request);
            //DateTime utc = DateTime.UtcNow;
            //DateTime timeAtTimeZone = Helper.ConvertUTCToTimeZone(utc, Helper.idTimeZoneUtc7);
            //newMedicalRecord.CreateDate = Helper.ConvertToTimeStamp(timeAtTimeZone);
            //newMedicalRecord.MedicalRecordId = $"{newMedicalRecord.CreateDate}";
            return await _medicalRecordRepository.CreateMedicalRecord(newMedicalRecord);
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> GetAllInactiveMedicalRecords()
        {
            return await _medicalRecordRepository.GetAllInactiveMedicalRecords();
        }

        public async Task<MedicalRecordModel> GetMedicalRecordById(string medicalRecordId)
        {
            MedicalRecord medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            return Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecord);
        }

        public async Task<UpdateMedicalRecordRes> PaidMedicalRecord(string medicalRecordId)
        {
            MedicalRecord medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            if (medicalRecord != null)
            {
                medicalRecord.IsPaid = true;
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
            }
            return new UpdateMedicalRecordRes() { Message = "Hồ sơ bệnh án không tồn tại" };
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByNameOrIdActiveNotFinishedExamination()
        {
            return await _medicalRecordRepository.GetMedicalRecordByNameOrIdActiveNotFinishedExamination();
        }

        public async Task<IEnumerable<MedicalRecordViewRes>> GetMedicalRecordByCustomerId(string customerId)
        {
            return await _medicalRecordRepository.GetMedicalRecordByCustomerId(customerId);
        }

        public async Task<UpdateMedicalRecordRes> UpdateDermatologyExamination(DermatologyExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if(medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.DermatologyExamination.DoctorId);
                if (!medicalRecord.Details.DermatologyExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.DermatologyExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateNeurologyExamination(NeurologyExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.NeurologyExamination.DoctorId);
                if (!medicalRecord.Details.NeurologyExamination.IsRegistered || user == null) return null;
                if (String.IsNullOrEmpty(medicalRecord.Details.NeurologyExamination.DoctorId)) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.NeurologyExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateInternalMedicineExamination(InternalMedicineExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.InternalMedicineExamination.DoctorId);
                if (!medicalRecord.Details.InternalMedicineExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.InternalMedicineExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateObstetricsAndGynecologyExamination(ObstetricsAndGynecologyExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.ObstetricsAndGynecologyExamination.DoctorId);
                if (!medicalRecord.Details.ObstetricsAndGynecologyExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.ObstetricsAndGynecologyExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateOphthalmologyExamination(OphthalmologyExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.OphthalmologyExamination.DoctorId);
                if (!medicalRecord.Details.OphthalmologyExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.OphthalmologyExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateOralAndMaxillofacialExamination(OralAndMaxillofacialExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.OralAndMaxillofacialExamination.DoctorId);
                if (!medicalRecord.Details.OralAndMaxillofacialExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.OralAndMaxillofacialExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateOtorhinolaryngologyExamination(OtorhinolaryngologyExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.OtorhinolaryngologyExamination.DoctorId);
                if (!medicalRecord.Details.OtorhinolaryngologyExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.OtorhinolaryngologyExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdatePhysicalExamination(PhysicalExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.PhysicalExamination.DoctorId);
                if (!medicalRecord.Details.PhysicalExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.PhysicalExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateSurgeryExamination(SurgeryExamination result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.SurgeryExamination.DoctorId);
                if (!medicalRecord.Details.SurgeryExamination.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.SurgeryExamination = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateBloodTests(BloodTests result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.BloodTests.DoctorId);
                if (!medicalRecord.Details.BloodTests.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.BloodTests = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateClinicalUrineTests(ClinicalUrineTests result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.ClinicalUrineTests.DoctorId);
                if (!medicalRecord.Details.ClinicalUrineTests.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.ClinicalUrineTests = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateAbdominalUltrasound(AbdominalUltrasound result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.AbdominalUltrasound.DoctorId);
                if (!medicalRecord.Details.AbdominalUltrasound.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.AbdominalUltrasound = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateBreastUltrasound(BreastUltrasound result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.BreastUltrasound.DoctorId);
                if (!medicalRecord.Details.BreastUltrasound.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.BreastUltrasound = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateCardiacUltrasoundProbes(CardiacUltrasoundProbes result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.CardiacUltrasoundProbes.DoctorId);
                if (!medicalRecord.Details.CardiacUltrasoundProbes.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.CardiacUltrasoundProbes = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateThyroidUltrasound(ThyroidUltrasound result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.ThyroidUltrasound.DoctorId);
                if (!medicalRecord.Details.ThyroidUltrasound.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.ThyroidUltrasound = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        public async Task<UpdateMedicalRecordRes> UpdateChestXray(ChestXray result, string mRecordId)
        {
            var medicalRecordRaw = await _medicalRecordRepository.GetMedicalRecordById(mRecordId);
            if (medicalRecordRaw != null)
            {
                var medicalRecord = Helper.AutoDTO<MedicalRecord, MedicalRecordModel>(medicalRecordRaw);
                var user = _userService.GetUserById(medicalRecord.Details.ChestXray.DoctorId);
                if (!medicalRecord.Details.ChestXray.IsRegistered || user == null) return null;
                if (user != null) medicalRecordRaw.ServiceUsed++;
                medicalRecord.Details.ChestXray = result;
                FinishExamination(medicalRecordRaw);
                medicalRecordRaw.Details = Helper.AutoDTO<MedicalRecordDetails, string>(medicalRecord.Details);
                return await _medicalRecordRepository.UpdateMedicalRecord(medicalRecordRaw);
            }
            return null;
        }

        private void FinishExamination(MedicalRecord medicalRecord)
        {
            if (medicalRecord.ServicesRegisted == medicalRecord.ServiceUsed)
            {
                medicalRecord.WasFinishedExamination = true;
            }
        }
    }
}
