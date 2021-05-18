using MedicalExamination.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace MedicalExamination.API.Controllers
{
    public class PrintController : ControllerBase
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IMedicalRecordService _mRecordService;

        public PrintController(IGeneratePdf generatePdf,
                               IMedicalRecordService mRecordService)
        {
            _generatePdf = generatePdf;
            _mRecordService = mRecordService;

        }
        [HttpGet("medicalRecordResult")]
        public async Task<IActionResult> Index(string MRecordId)
        {
            var MRecord = await _mRecordService.GetMedicalRecordById(MRecordId);
            return await _generatePdf.GetPdf("Views/print/print.cshtml", MRecord);
        }
    }
}
