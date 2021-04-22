using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalService
{
    public class CreateMedicalServiceRes
    {
        public int MServiceId { get; set; }
        public string Message { get; set; }
        public bool Success => MServiceId > 0;
    }
}
