using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalService
{
    public class UpdateMedicalServiceRes
    {
        public MedicalExamination.Domain.Entities.MedicalService MedicalService { get; set; }
        public string Message { get; set; }
        public bool Success => MedicalService != null;
    }
}
