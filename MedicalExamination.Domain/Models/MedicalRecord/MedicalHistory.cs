using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord
{
    public class MedicalHistory
    {
        public bool HaveOrNot { get; set; }
        public string Details { get; set; }
        public MedicalHistory()
        {
            HaveOrNot = false;
        }
    }
}
