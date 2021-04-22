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
    [ApiController]
    public class GMExaminationController : ControllerBase
    {
        private IGMExaminationServices _gMExaminationServices;

        public GMExaminationController(IGMExaminationServices gMExaminationServices)
        {
            _gMExaminationServices = gMExaminationServices;
        }

        /// <summary>
        /// Get all Group Medical Examination Records 
        /// </summary>
        /// <returns>List all Group Medical Examination</returns>
        [HttpGet("api/GMExamination/GetsAllGMExamination")]
        public async Task<IActionResult> GetAllGMExamintion()
        {
            return Ok(await _gMExaminationServices.GetAllGMExaminations());
        }

        /// <summary>
        /// Get a Group Medical Examination Records By Id 
        /// </summary>
        /// <returns>A Group Medical Examination</returns>
        [HttpGet("api/GMExamination/GetGMExamination/{GMExaminationId}")]
        public async Task<IActionResult> GetGMExaminationById(string GMExaminationId)
        {
            return Ok(await _gMExaminationServices.GetGMExaminationById(GMExaminationId));
        }

        /// <summary>
        /// Get a Group Medical Examination Records By OrganizationId 
        /// </summary>
        /// <returns>A Group Medical Examination</returns>
        [HttpGet("api/GMExamination/GetGMExaminationByOrganizationId/{OrganizationId}")]
        public async Task<IActionResult> GetGMExaminationByOrganizationId(string OrganizationId)
        {
            return Ok(await _gMExaminationServices.GetGMExaminationByOrganizationId(OrganizationId));
        }

        ///<summary>
        ///Create A Group Medical Examination Record
        ///</summary>
        ///<param name="request"></param>
        ///<returns>New Group Medical Examination</returns>
        [HttpPost("api/GMExamination/CreateGMExamination")]
        public async Task<IActionResult> CreateGMExamination(CreateGMExaminationReq request)
        {
            return Ok(await _gMExaminationServices.CreateGMExamination(request));
        }

        ///<summary>
        ///Update A Group Medical Examination Record
        ///</summary>
        ///<param name="request"></param>
        ///<returns>A Group Medical Examination Updated</returns>
        [HttpPut("api/GMExamination/UpdateGMExamination")]
        public async Task<IActionResult> UpdateGMExamination(UpdateGMExaminationReq request)
        {
            return Ok(await _gMExaminationServices.UpdateGMExamination(request));
        }

    }
}
