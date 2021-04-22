using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.MedicalService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class MedicalServiceController: ControllerBase
    {
        private readonly IMedicalServiceService _medicalServiceService;

        public MedicalServiceController(IMedicalServiceService medicalServiceService)
        {
            _medicalServiceService = medicalServiceService;
        }

        [HttpPost("api/MedicalService/CreateMedicalService")]
       public async Task<IActionResult> CreateMedicalService(CreateMedicalServiceReq request)
        {
            return Ok(await _medicalServiceService.CreateMedicalService(request));
        }


        [HttpPut("api/MedicalService/UpdateMedicalService")]
        public async Task<IActionResult> UpdateMedicalService(UpdateMedicalServiceReq request)
        {
            return Ok(await _medicalServiceService.UpdateMedicalService(request));
        }


        [HttpGet("api/MedicalService/GetMedicalServiceByMedicalServiceId/{medicalServiceId}")]
        public async Task<IActionResult> GetMedicalServiceByMedicalServiceId(string medicalServiceId)
        {
            return Ok(await _medicalServiceService.GetMedicalServiceByMedicalServiceId(medicalServiceId));
        }


        [HttpGet("api/MedicalService/GetMedicalServiceByDepartmentId/{departmentId}")]

        public async Task<IActionResult> GetMedicalServiceByDepartmentId(string departmentId)
        {
            return Ok(await _medicalServiceService.GetMedicalServiceByDepartmentId(departmentId));
        }

    }
}
