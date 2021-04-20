using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class InternalMedicineExamination : AExaminationRooms // Nội khoa
    {

        public string Circulatory { get; set; }
        public byte CirculatoryLevel { get; set; }
        public string Respiratory { get; set; }
        public byte RespiratoryLevel { get; set; }
        public string Alimentary { get; set; }
        public byte AlimentaryLevel { get; set; }
        public string NephroUrology { get; set; }
        public byte NephroUrologyLevel { get; set; }
        public string Musculoskeletal { get; set; }
        public byte MusculoskeletalLevel { get; set; }
    }
}
