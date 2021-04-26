using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests.Account
{
    public class AccountLoginReq
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
