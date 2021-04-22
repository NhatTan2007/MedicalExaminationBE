using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests.Department
{
    public class CreateDepartmentReq
    {
        private string _departmentName;
        private  bool _isActive;

        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
    }
}
