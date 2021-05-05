using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Entities
{
   public class GroupMedicalExamination
    {
        private string _gMExaminationId;
        private DateTime _dateStart;
        private DateTime _dateEnd;
        private decimal _advances;
        private decimal _discount;
        private string _organizationId;

        public string GMExaminationId { get => _gMExaminationId; set => _gMExaminationId = value; }
        public DateTime DateStart { get => _dateStart; set => _dateStart = value; }
        public DateTime DateEnd { get => _dateEnd; set => _dateEnd = value; }
        public decimal Advances { get => _advances; set => _advances = value; }
        public decimal Discount { get => _discount; set => _discount = value; }
        public string OrganizationId { get => _organizationId; set => _organizationId = value; }
       
    }
}
