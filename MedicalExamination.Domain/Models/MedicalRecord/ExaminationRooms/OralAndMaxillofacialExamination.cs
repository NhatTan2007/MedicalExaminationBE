using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class OralAndMaxillofacialExamination : AExaminationRooms //Răng hàm mặt
    {
        public string UpperJaw { get; set; }
        public string LowerJaw { get; set; }
        public string OralAndMaxillofacialDiseases { get; set; }
        public byte OralAndMaxillofacialLevel { get; set; }
    }
}
