using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class PhysicalExamination : AExaminationRooms //Thể lực
    {
        public ushort Height { get; set; }
        public ushort Weight { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BMIIndex { get; set; }
        public ushort HeartBeat { get; set; }
        public byte PhysicalLevel { get; set; }
    }
}
