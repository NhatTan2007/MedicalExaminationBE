using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalRecord
{
    public class QueryMedicalRecordsRes
    {
        public IEnumerable<MedicalRecordViewRes> MedicalRecords { get; set; }
        public int TotalMedicalRecords { get; set; }
    }
}
