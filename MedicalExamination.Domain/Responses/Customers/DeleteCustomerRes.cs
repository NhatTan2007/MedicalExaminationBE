using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Customers
{
    public class DeleteCustomerRes
    {
        public string CustomerId { get; set; }
        public string Message { get; set; }
        public bool Success => !String.IsNullOrEmpty(CustomerId);

    }
}
