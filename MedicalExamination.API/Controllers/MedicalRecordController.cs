using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.MedicalRecord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class MedicalRecordController : ControllerBase
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
        /// <returns>New Medical Record</returns>
        [HttpPost("api/medicalrecord/create")]
        public async Task<IActionResult> CreateMedicalRecord(CreateMedicalRecordReq request)
        {
            return Ok(await _medicalRecordService.CreateMedicalRecord(request));
        }
    }
}
