using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class OtorhinolaryngologyExamination : AExaminationRooms //Tai mũi họng
    {
        public byte LeftEarNormal { get; set; }
        public byte RightEarNormal { get; set; }
        public byte LeftEarWhisper { get; set; }
        public byte RightEarWhisper { get; set; }
        public string OtorhinolaryngologyDiseases { get; set; }
        public byte OtorhinolaryngologyLevel { get; set; }
    }
}
