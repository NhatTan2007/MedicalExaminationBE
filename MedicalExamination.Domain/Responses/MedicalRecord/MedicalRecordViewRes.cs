﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.MedicalRecord
{
    public class MedicalRecordViewRes
    {
        private string _medicalRecordId;
        private string _customerFirstName;
        private string _customerLastName;
        private double _createDate;
        private bool _isActive;
        private bool _isPaid;
        private string _reasonCancel;

        public string MedicalRecordId { get => _medicalRecordId; set => _medicalRecordId = value; }
        public string CustomerFirstName { get => _customerFirstName; set => _customerFirstName = value; }
        public string CustomerLastName { get => _customerLastName; set => _customerLastName = value; }
        public string CustomerFullName => $"{_customerLastName} {_customerFirstName}";
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public bool IsPaid { get => _isPaid; set => _isPaid = value; }
        public double CreateDate { get => _createDate; set => _createDate = value; }
        public string ReasonCancel { get => _reasonCancel; set => _reasonCancel = value; }
    }
}
