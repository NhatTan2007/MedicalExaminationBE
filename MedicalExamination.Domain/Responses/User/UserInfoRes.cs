using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.User
{
    public class UserInfoRes
    {
        private string _userId;
        private string _firstName;
        private string _lastName;
        private string _departmentId;
        private string _departmentName;
        private string _titles;
        private string _avatar;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string DepartmentId { get => _departmentId; set => _departmentId = value; }
        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
        public string Titles { get => _titles; set => _titles = value; }
        public string Avatar { get => _avatar; set => _avatar = value; }
        public string FullName => $"{_lastName} {_firstName}";
        public string UserId { get => _userId; set => _userId = value; }
    }
}
