using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Customers
{
    public class QueryCustomerRes
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCustomer { get; set; }
    }
}
