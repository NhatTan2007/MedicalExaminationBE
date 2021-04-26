﻿using MedicalExamination.BAL.Interface;
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
        /// <param name="medicalRecordId"></param>
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
        /// Search by name of patient or id of medical record is active but not finish examination
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>list medical record</returns>
        [HttpGet("searchActive/{searchKey}")]
        public async Task<IActionResult> SearchMedicalRecordsByNameOrIdActiveNotFinishedExamination(string searchKey)
        {
            return Ok(await _medicalRecordService.SearchMedicalRecordByNameOrIdActiveNotFinishedExamination(searchKey));
        }
    }
}
