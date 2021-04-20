using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class BloodTests : AExaminationRooms //Xét nghiệm máu
    {
        public int HCAmount { get; set; } //Số lượng HC
        public int LeukocytesAmount { get; set; } // Số lượng bạch cầu
        public int PlateletsAmount { get; set; } // Số lượng tiểu cầu
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BloodSugar { get; set; } //Đường huyết
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ure { get; set; }
        public int Creatinin { get; set; }
        public int ASATGOT { get; set; }
        public int ALATGPT { get; set; }
    }
}
