using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MedicalExamination.Domain.Entities
{
    public class AppIdentityUser : IdentityUser
    {
        private string _employeeCode;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _address;
        private string _titles;
        private bool _isActive;
        private string _avatar;
        private string _signature;
        private string _refreshToken;
        [MaxLength(10)]
        public string EmployeeCode { get => _employeeCode; set => _employeeCode = value; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get => _firstName; set => _firstName = value; }
        [Required]
        [MaxLength(70)]
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        [MaxLength(200)]
        public string Address { get => _address; set => _address = value; }
        [MaxLength(40)]
        public string Titles { get => _titles; set => _titles = value; }
        [Required]
        public bool IsActive { get => _isActive; set => _isActive = value; }
        [MaxLength(50)]
        public string DepartmentId { get; set; }
        [ForeignKey(name: "DepartmentId")]
        public Department Department { get; set; }
        [MaxLength(200)]
        public string Avatar { get => _avatar; set => _avatar = value; }
        [MaxLength(200)]
        public string Signature { get => _signature; set => _signature = value; }
        [JsonIgnore]
        public string RefreshToken { get => _refreshToken; set => _refreshToken = value; }

        public AppIdentityUser()
        {
            _isActive = true;
        }
    }
}
