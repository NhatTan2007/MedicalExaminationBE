using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms;
using MedicalExamination.Domain.Requests.MedicalRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class MedicalRecordController : BaseApiController
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        /// <summary>
        /// Create new Medical record
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response about create new medical record</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateMedicalRecord(CreateMedicalRecordReq request)
        {
            return Ok(await _medicalRecordService.CreateMedicalRecord(request));
        }

        /// <summary>
        /// Get specific medical record by id
        /// </summary>
        /// <returns>exists medical record</returns>
        [HttpGet("{medicalRecordId}")]
        public async Task<IActionResult> GetMedicalRecordById(string medicalRecordId)
        {
            return Ok(await _medicalRecordService.GetMedicalRecordById(medicalRecordId));
        }

        /// <summary>
        /// Active specific medical record
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <returns>Response of update medical record</returns>
        [HttpGet("active/{medicalRecordId}")]
        public async Task<IActionResult> ActiveMedicalRecordBy(string medicalRecordId)
        {
            return Ok(await _medicalRecordService.ActiveMedicalRecord(medicalRecordId));
        }

        /// <summary>
        /// Change exists medical record to paid
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <returns>Response of update medical record</returns>
        [HttpGet("paid/{medicalRecordId}")]
        public async Task<IActionResult> PaidMedicalRecordBy(string medicalRecordId)
        {
            return Ok(await _medicalRecordService.GetMedicalRecordById(medicalRecordId));
        }

        /// <summary>
        /// Get medical record is active but not finish examination
        /// </summary>
        /// <returns>list medical record</returns>
        [HttpGet("getActive")]
        public async Task<IActionResult> GetMedicalRecordsByNameOrIdActiveNotFinishedExamination()
        {
            return Ok(await _medicalRecordService.GetMedicalRecordByNameOrIdActiveNotFinishedExamination());
        }

        /// <summary>
        /// Get medical records of customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>list medical records</returns>
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetMedicalRecordsByCustomerId(string customerId)
        {
            return Ok(await _medicalRecordService.GetMedicalRecordByCustomerId(customerId));
        }

        /// <summary>
        /// Update DermatologyExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/dermatologyExamination")]
        public async Task<IActionResult> UpdateDermatologyExamination([FromBody] DermatologyExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateDermatologyExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update NeurologyExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/neurologyExamination")]
        public async Task<IActionResult> UpdateNeurologyExamination([FromBody] NeurologyExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateNeurologyExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update InternalMedicineExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/internalMedicineExamination")]
        public async Task<IActionResult> UpdateInternalMedicineExamination([FromBody] InternalMedicineExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateInternalMedicineExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update ObstetricsAndGynecologyExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/obstetricsAndGynecologyExamination")]
        public async Task<IActionResult> UpdateObstetricsAndGynecologyExamination([FromBody] ObstetricsAndGynecologyExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateObstetricsAndGynecologyExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update OphthalmologyExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/ophthalmologyExamination")]
        public async Task<IActionResult> UpdateOphthalmologyExamination([FromBody] OphthalmologyExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateOphthalmologyExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update OralAndMaxillofacialExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/oralAndMaxillofacialExamination")]
        public async Task<IActionResult> UpdateOralAndMaxillofacialExamination([FromBody] OralAndMaxillofacialExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateOralAndMaxillofacialExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update OtorhinolaryngologyExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/otorhinolaryngologyExamination")]
        public async Task<IActionResult> UpdateOtorhinolaryngologyExamination([FromBody] OtorhinolaryngologyExamination result, string mRecordId)
        {
            var response = await _medicalRecordService.UpdateOtorhinolaryngologyExamination(result, mRecordId);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        /// <summary>
        /// Update PhysicalExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/physicalExamination")]
        public async Task<IActionResult> UpdatePhysicalExamination([FromBody] PhysicalExamination result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdatePhysicalExamination(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update SurgeryExamination result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/surgeryExamination")]
        public async Task<IActionResult> UpdateSurgeryExamination([FromBody] SurgeryExamination result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateSurgeryExamination(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update BloodTests result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/bloodTests")]
        public async Task<IActionResult> UpdateBloodTests([FromBody] BloodTests result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateBloodTests(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update ClinicalUrineTests result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/clinicalUrineTests")]
        public async Task<IActionResult> UpdateClinicalUrineTests([FromBody] ClinicalUrineTests result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateClinicalUrineTests(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update AbdominalUltrasound result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/abdominalUltrasound")]
        public async Task<IActionResult> UpdateAbdominalUltrasound([FromBody] AbdominalUltrasound result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateAbdominalUltrasound(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update BreastUltrasound result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/breastUltrasound")]
        public async Task<IActionResult> UpdateBreastUltrasound([FromBody] BreastUltrasound result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateBreastUltrasound(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update CardiacUltrasoundProbes result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/cardiacUltrasoundProbes")]
        public async Task<IActionResult> UpdateCardiacUltrasoundProbes([FromBody] CardiacUltrasoundProbes result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateCardiacUltrasoundProbes(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update ThyroidUltrasound result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/thyroidUltrasound")]
        public async Task<IActionResult> UpdateThyroidUltrasound([FromBody] ThyroidUltrasound result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateThyroidUltrasound(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update ChestXray result for specific medical record
        /// </summary>
        /// <param name="result"></param>
        /// <param name="mRecordId"></param>
        /// <returns>response result update</returns>
        [HttpPut("{mRecordId}/chestXray")]
        public async Task<IActionResult> UpdateChestXray([FromBody] ChestXray result, string mRecordId)
        {
            if (ModelState.IsValid)
            {
                var response = await _medicalRecordService.UpdateChestXray(result, mRecordId);
                if (response != null) return Ok(response);
            }
            return BadRequest();
        }

    }
}
