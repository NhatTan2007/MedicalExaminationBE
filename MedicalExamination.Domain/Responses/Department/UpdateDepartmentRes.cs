using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Department
{
   public class UpdateDepartmentRes
            {
                public Entities.Department Department { get; set; }
                public string Message { get; set; }
                public bool Success => Department != null;
            }
}
