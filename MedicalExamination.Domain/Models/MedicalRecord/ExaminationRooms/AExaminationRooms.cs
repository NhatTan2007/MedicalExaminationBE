using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public abstract class AExaminationRooms
    {
        public int MServiceId { get; set; }
        public bool IsRegistered { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        public AExaminationRooms()
        {
            IsRegistered = false;
        }
    }
}
