using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class ObstetricsAndGynecologyExamination : AExaminationRooms //Sản phụ khoa
    {
        public string ObstetricsAndGynecology { get; set; }
        public byte ObstetricsAndGynecologyLevel { get; set; }
    }
}
