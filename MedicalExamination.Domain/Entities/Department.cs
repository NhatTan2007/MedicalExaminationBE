using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalExamination.Domain.Entities
{
    public class Department
    {
        private string _departmentId;
        private string _departmentName;
        private bool _isActive;
        [Key]
        [MaxLength(50)]
        public string DepartmentId { get => _departmentId; set => _departmentId = value; }
        [MaxLength(200)]
        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
        [Required]
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public Department()
        {
            _isActive = true;
        }
    }
}
