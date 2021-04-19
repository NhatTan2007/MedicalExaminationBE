using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalRecord
{
    public class UpdateMedicalRecordRes
    {
        public MedicalExamination.Domain.Entities.MedicalRecord MedicalRecord { get; set; }
        public string Message { get; set; }
        public bool Success => MedicalRecord != null;
    }
}
