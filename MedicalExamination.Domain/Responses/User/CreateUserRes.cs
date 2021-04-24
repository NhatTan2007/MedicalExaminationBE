using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.User
{
    public class CreateUserRes
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(UserId);
    }
}
