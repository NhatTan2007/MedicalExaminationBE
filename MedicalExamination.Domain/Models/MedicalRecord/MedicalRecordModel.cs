using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord
{
    public class MedicalRecordModel
    {
        private string _medicalRecordId;
        private MedicalHistoryForm _medicalHistory;
        private MedicalRecordDetails _details;
        private double _createDate;
        private bool _isGroup;
        private string _customerFirstName;
        private string _customerLastName;
        private bool _isActive;
        private string _organizationId;
        private string _gMExaminationId;
        private double _dateCompleted;
        private bool _isPaid;
        private decimal _totalAmount;
        private bool _wasFinishedExamination;
        private string _customerId;
        private int _servicesRegisted;
        private int _serviceUsed;
        private string _reasonCancel;

        public string MedicalRecordId { get => _medicalRecordId; set => _medicalRecordId = value; }
        public MedicalHistoryForm MedicalHistory { get => _medicalHistory; set => _medicalHistory = value; }
        public MedicalRecordDetails Details { get => _details; set => _details = value; }
        public double CreateDate { get => _createDate; set => _createDate = value; }
        public bool IsGroup { get => _isGroup; set => _isGroup = value; }
        public string CustomerFirstName { get => _customerFirstName; set => _customerFirstName = value; }
        public string CustomerLastName { get => _customerLastName; set => _customerLastName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string OrganizationId { get => _organizationId; set => _organizationId = value; }
        public string GMExaminationId { get => _gMExaminationId; set => _gMExaminationId = value; }
        public double DateCompleted { get => _dateCompleted; set => _dateCompleted = value; }
        public bool IsPaid { get => _isPaid; set => _isPaid = value; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        public bool WasFinishedExamination { get => _wasFinishedExamination; set => _wasFinishedExamination = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public int ServicesRegisted { get => _servicesRegisted; set => _servicesRegisted = value; }
        public int ServiceUsed { get => _serviceUsed; set => _serviceUsed = value; }
        public string ReasonCancel { get => _reasonCancel; set => _reasonCancel = value; }
    }
}
