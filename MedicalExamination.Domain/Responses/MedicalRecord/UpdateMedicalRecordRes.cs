using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalRecord
{
    public class UpdateMedicalRecordRes
    {
        public string MedicalRecordId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(MedicalRecordId);
    }
}
