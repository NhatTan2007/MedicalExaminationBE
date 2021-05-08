using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Account
{
    public class AccountLoginRes
    {
        public string DepartmentId { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
    }
}
