using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests;
using MedicalExamination.Domain.Requests.GroupMedicalExamination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class GMExaminationController : BaseApiController
    {
        private IGMExaminationService _gMExaminationServices;

        public GMExaminationController(IGMExaminationService gMExaminationServices)
        {
            _gMExaminationServices = gMExaminationServices;
        }

        /// <summary>
        /// Get all Group Medical Examination Records 
        /// </summary>
        /// <returns>List all Group Medical Examination</returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllGMExamintion()
        {
            return Ok(await _gMExaminationServices.GetAllGMExaminations());
        }

        /// <summary>
        /// Get a Group Medical Examination Records By Id 
        /// </summary>
        /// <param name="GMExaminationId"></param>
        /// <returns>Specific Group examination record</returns>
        [HttpGet("{GMExaminationId}")]
        public async Task<IActionResult> GetGMExaminationById(string GMExaminationId)
        {
            return Ok(await _gMExaminationServices.GetGMExaminationById(GMExaminationId));
        }

        /// <summary>
        /// Get group examination records by organization Id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns>List Group examination records has specific OrganizationId</returns>
        [HttpGet("organization/{organizationId}")]
        public async Task<IActionResult> GetGMExaminationByOrganizationId(string organizationId)
        {
            return Ok(await _gMExaminationServices.GetGMExaminationByOrganizationId(organizationId));
        }

        ///<summary>
        ///Create A Group Medical Examination
        ///</summary>
        ///<param name="request"></param>
        ///<returns>Response when create a new group medical examination</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateGMExamination(CreateGMExaminationReq request)
        {
            return Ok(await _gMExaminationServices.CreateGMExamination(request));
        }

        ///<summary>
        ///Update data of Group Medical Examination
        ///</summary>
        ///<param name="request"></param>
        ///<returns>Response when update group medical examination data</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateGMExamination(UpdateGMExaminationReq request)
        {
            return Ok(await _gMExaminationServices.UpdateGMExamination(request));
        }

    }
}
