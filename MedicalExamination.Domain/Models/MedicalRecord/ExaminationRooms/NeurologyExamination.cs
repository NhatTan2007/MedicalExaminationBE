using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms
{
    public class NeurologyExamination : AExaminationRooms //Thần kinh - tâm thần
    {
        public string Neurosurgery { get; set; }
        public byte NeurosurgeryLevel { get; set; }
        public string Psychiatry { get; set; }
        public byte PsychiatryLevel { get; set; }
    }
}
