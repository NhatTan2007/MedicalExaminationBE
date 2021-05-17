using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Responses.Customers
{
    class PaginationSearchCustomer
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int TotalCustomer { get; set; }
    }
}
