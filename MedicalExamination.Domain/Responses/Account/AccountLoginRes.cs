using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Account
{
    public class AccountLoginRes
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
