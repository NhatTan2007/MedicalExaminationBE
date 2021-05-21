using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using MedicalExamination.Domain.Models.MedicalRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Rotativa.AspNetCore;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    
    public class PdfCreatorController : BaseApiController
    {
        private readonly IMedicalRecordService _mRecordService;
        private readonly IViewRenderService _renderService;
        private readonly IMedicalRecordRepository _mRecordRepository;
        private readonly IWebHostEnvironment _env;

        public PdfCreatorController(IMedicalRecordService mRecordService,
                                    IMedicalRecordRepository mRecordRepository,
                                    IWebHostEnvironment env,
                                    IViewRenderService renderService)
        {
            _mRecordService = mRecordService;
            _renderService = renderService;
            _mRecordRepository = mRecordRepository;
            _env = env;
        }

        ///// <summary>
        ///// Generate Examination Result in pdf
        ///// </summary>
        ///// <param name="MRecordId"></param>
        ///// <returns></returns>
        //[HttpGet("medicalRecordResult/{MRecordId}")]
        //public async Task<IActionResult> Index(string MRecordId)
        //{
        //    var MRecord = await _mRecordService.GetMedicalRecordById(MRecordId);
        //    if (MRecord.DateCompleted > 0)
        //    {
        //        MRecord.WasPrinted = true;
        //        await _mRecordRepository.UpdateMedicalRecord(Helper.AutoDTO<MedicalRecordModel, MedicalRecord>(MRecord));
        //        var converter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);
        //        var settings = new BlinkConverterSettings();
        //        settings.PdfPageSize = new SizeF(PdfPageSize.A4);
        //        settings.Margin.All = 20;
        //        settings.MediaType = MediaType.Print;
        //        settings.BlinkPath = Path.Combine(_env.ContentRootPath, "BlinkBinariesWindows");
        //        converter.ConverterSettings = settings;
        //        string html = await _renderService.RenderToStringAsync<MedicalRecordModel>
        //                                ("/Views/print/print.cshtml", MRecord);
        //        var document = converter.Convert(html, "~/css/print.css");
        //        document.EnableMemoryOptimization = true;

        //        MemoryStream stream = new MemoryStream();
        //        document.Save(stream);
        //        return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, $"{MRecordId}.pdf");
        //    }
        //    return BadRequest();
        //}

        /// <summary>
        /// Generate Examination Result in pdf
        /// </summary>
        /// <param name="MRecordId"></param>
        /// <returns></returns>
        [HttpGet("medicalRecordResult/{MRecordId}")]
        public async Task<IActionResult> Index(string MRecordId)
        {
            var MRecord = await _mRecordService.GetMedicalRecordById(MRecordId);
            if (MRecord.DateCompleted > 0)
            {
                MRecord.WasPrinted = true;
                await _mRecordRepository.UpdateMedicalRecord(Helper.AutoDTO<MedicalRecordModel, MedicalRecord>(MRecord));
                return new ViewAsPdf("/Views/print/print.cshtml", MRecord);
            }
            return BadRequest();
        }


    }
}
