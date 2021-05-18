using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalService
{
    public class QuerryMSerciceRes
    {
        public IEnumerable<MedicalExamination.Domain.Entities.MedicalService> MedicalService { get; set; }
        public int TotalMedicalSevices { get; set; }
    }
}
