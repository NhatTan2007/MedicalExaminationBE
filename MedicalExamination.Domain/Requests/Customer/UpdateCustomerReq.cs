using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests.Customers
{
    public class UpdateCustomerReq
    {
        private string _customerId;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _email;
        private string _adress;
        private string _phoneNumber;
        private string _identityNumber;

        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Email { get => _email; set => _email = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string IdentityNumber { get => _identityNumber; set => _identityNumber = value; }
    }
}
