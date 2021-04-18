using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests
{
    public class CreateOrganizationReq
    {
        private string _organizationName;
        private string _organizationPhoneNumber;
        private string _organizationEmail;
        private string _organizationAddress;
        private string _personContact;
        private string _phoneContact;
        private string _emailContact;

        public string OrganizationName { get => _organizationName; set => _organizationName = value; }
        public string OrganizationPhoneNumber { get => _organizationPhoneNumber; set => _organizationPhoneNumber = value; }
        public string OrganizationEmail { get => _organizationEmail; set => _organizationEmail = value; }
        public string OrganizationAddress { get => _organizationAddress; set => _organizationAddress = value; }
        public string PersonContact { get => _personContact; set => _personContact = value; }
        public string PhoneContact { get => _phoneContact; set => _phoneContact = value; }
        public string EmailContact { get => _emailContact; set => _emailContact = value; }
    }
}
