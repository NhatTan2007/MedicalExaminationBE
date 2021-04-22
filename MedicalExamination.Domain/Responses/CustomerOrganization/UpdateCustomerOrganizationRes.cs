using System;
using System.Collections.Generic;
using System.Text;


namespace MedicalExamination.Domain.Responses.CustomerOrganization
{
    public class UpdateCustomerOrganizationRes
    {
        public MedicalExamination.Domain.Entities.CustomerOrganization CustomerOrganization { get; set; }
        public string Message { get; set; }
        public bool Success => CustomerOrganization != null;
    }
}
