using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Customers
{
    public class RestoreCustomerRes
    {
        public string CustomerId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(CustomerId);
    }
}
