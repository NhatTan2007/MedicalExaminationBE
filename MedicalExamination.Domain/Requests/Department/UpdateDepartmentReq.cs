using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests.Department
{
     public class UpdateDepartmentReq
     {
        private string  _departmentId;
        private string  _departmentName;
        private bool    _isActive;

        public string DepartmentId { get => _departmentId; set => _departmentId = value; }
        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
    }
}
