using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Organization
{
    public class QuerryOrganizationRes
    {
        public IEnumerable<MedicalExamination.Domain.Entities.Organization> Organization { get; set; }
        public int TotalOrganization { get; set; }
    }
}
