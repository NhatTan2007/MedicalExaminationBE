using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.User
{
    public class UserViewModel
    {
        private string _userId;
        private string _employeeCode;
        private string _firstName;
        private string _lastName;
        private bool _isActive;
        private string _departmentId;
        private string _departmentName;

        public string UserId { get => _userId; set => _userId = value; }
        public string EmployeeCode { get => _employeeCode; set => _employeeCode = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string DepartmentId { get => _departmentId; set => _departmentId = value; }
        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
    }
}
