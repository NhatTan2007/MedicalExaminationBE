using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Account
{
    public class AccountLoginResult
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
