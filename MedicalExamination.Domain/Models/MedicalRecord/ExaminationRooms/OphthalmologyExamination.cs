using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class OphthalmologyExamination : AExaminationRooms //Mắt
    {
        public string RightEyeSightWithoutGlass { get; set; }
        public string LeftEyeSightWithoutGlass { get; set; }
        public string RightEyeSightWithGlass { get; set; }
        public string LeftEyeSightWithGlass { get; set; }
        public string EyeDiseases { get; set; }
        public byte OphthalmologyLevel { get; set; }
    }
}
