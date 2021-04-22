using System;
using System.Collections.Generic;
using System.Text;
using MedicalExamination.Domain.Entities;

namespace MedicalExamination.Domain.Responses.GroupMedicalExamination
{
    public class CreateGMExaminationRes
    {
        public string GMExaminationId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(GMExaminationId);
    }
}
