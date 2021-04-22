using MedicalExamination.Domain.Models.MedicalRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalExamination.Domain.Requests.MedicalRecord
{
    public class CreateMedicalRecordReq
    {
        private MedicalHistoryForm _medicalHistory;
        private MedicalRecordDetails _details;
        private string _reasonToExamination;
        private bool _isGroup;
        private string _customerFirstName;
        private string _customerLastName;
        private bool _isActive;
        private string _organizationId;
        private string _gMExaminationId;
        private bool _isPaid;
        private decimal _totalAmount;
        private bool _wasFinishedExamination;
        private string _customerId;

        public MedicalHistoryForm MedicalHistory { get => _medicalHistory; set => _medicalHistory = value; }
        public MedicalRecordDetails Details { get => _details; set => _details = value; }
        public bool IsGroup { get => _isGroup; set => _isGroup = value; }
        public string CustomerFirstName { get => _customerFirstName; set => _customerFirstName = value; }
        public string CustomerLastName { get => _customerLastName; set => _customerLastName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string OrganizationId { get => _organizationId; set => _organizationId = value; }
        public string GMExaminationId { get => _gMExaminationId; set => _gMExaminationId = value; }
        public bool IsPaid { get => _isPaid; set => _isPaid = value; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        public bool WasFinishedExamination { get => _wasFinishedExamination; set => _wasFinishedExamination = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string ReasonToExamination { get => _reasonToExamination; set => _reasonToExamination = value; }
    }
}