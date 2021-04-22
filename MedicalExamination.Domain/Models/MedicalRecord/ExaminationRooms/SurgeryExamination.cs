using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class SurgeryExamination : AExaminationRooms //Ngoại khoa
    {
        public string Surgery { get; set; }
        public byte SurgeryLevel { get; set; }
    }
}
