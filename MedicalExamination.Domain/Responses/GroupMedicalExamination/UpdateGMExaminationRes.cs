using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MedicalExamination.Domain.Responses.GroupMedicalExamination
{
   public class UpdateGMExaminationRes
    {
        public Entities.GroupMedicalExamination GMExamination { get; set; }
        public string Message { get; set; }
        public bool Success => GMExamination != null;
    }
}
