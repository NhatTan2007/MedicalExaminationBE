using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class ClinicalUrineTests : AExaminationRooms // Xét nghiệm nước tiểu
    {
        public bool Sugar { get; set; }
        public bool Protein { get; set; }
        public string Other { get; set; }
    }
}
