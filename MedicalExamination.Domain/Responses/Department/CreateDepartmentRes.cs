using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Department
{
  public class CreateDepartmentRes
         {
            public string DepartmentId { get; set; }
            public string Message { get; set; }
            public bool Success => !String.IsNullOrEmpty(DepartmentId);
         }
}
