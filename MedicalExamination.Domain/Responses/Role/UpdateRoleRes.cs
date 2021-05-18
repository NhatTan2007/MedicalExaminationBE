using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Role
{
   public class UpdateRoleRes
   {
        public string NameRole { get; set; }
        public string Message { get; set; }
        public bool Success => NameRole != null;
   }
}
