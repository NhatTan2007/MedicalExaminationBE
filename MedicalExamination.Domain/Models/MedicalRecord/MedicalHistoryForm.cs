using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord
{
    public class MedicalHistoryForm
    {
        public MedicalHistory MedicalHistoryCustomer { get; set; }
        public MedicalHistory MedicalHistoryFamily { get; set; }
        public AnotherQuestions AnotherQuestions { get; set; }
    }
}
