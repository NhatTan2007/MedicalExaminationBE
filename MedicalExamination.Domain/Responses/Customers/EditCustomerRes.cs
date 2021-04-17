using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Customers
{
    public class EditCustomerRes
    {
        public Entities.Customers Customer { get; set; }
        public string Message { get; set; }
        public bool Success => Customer != null;
    }
}
