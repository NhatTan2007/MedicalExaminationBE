using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Entities
{
    public class MedicalService
    {
        private int _mServiceId;
        private string _mServiceName;
        private decimal _price;
        private bool _isActive;
        private string _departmentId;

        public int MServiceId { get => _mServiceId; set => _mServiceId = value; }
        public string MServiceName { get => _mServiceName; set => _mServiceName = value; }
        public decimal Price { get => _price; set => _price = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string DepartmentId { get => _departmentId; set => _departmentId = value; }
    }
}
