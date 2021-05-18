using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class FinalExaminationResult : AExaminationRooms
    {
        public byte HealthyLevel { get; set; }
        public string OtherDiseases { get; set; }
    }
}
