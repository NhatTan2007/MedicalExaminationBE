using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class DermatologyExamination : AExaminationRooms //Da liễu
    {
        public string Dermatology { get; set; }
        public byte DermatologyLevel { get; set; }
    }
}
