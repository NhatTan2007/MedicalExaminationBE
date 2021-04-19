using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.OrganizationRes
{
   public class CreateOrganizationRes
    {
        public string OrganizationId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(OrganizationId);
    }
}
