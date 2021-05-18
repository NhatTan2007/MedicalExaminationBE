using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Role
{
   public class CreateRoleRes
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public   string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(RoleId);
    }
}
