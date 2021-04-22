using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Entities
{
    public class CustomerOrganization
    {
        private string _customerId;
        private string _organizationId;
        private bool _isActive;
        private string _customerFirstName;
        private string _customerLasNtame;

        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string OrganizationId { get => _organizationId; set => _organizationId = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string CustomerFirstName { get => _customerFirstName; set => _customerFirstName = value; }
        public string CustomerLasNtame { get => _customerLasNtame; set => _customerLasNtame = value; }
    }
}
