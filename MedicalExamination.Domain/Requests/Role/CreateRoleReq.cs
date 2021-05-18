using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Requests.Role
{
    public class CreateRoleReq
    {
        private string _roleName;
        private bool _isActive;
        private byte _rolePriority;

        public string RoleName { get => _roleName; set => _roleName = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public byte RolePriority { get => _rolePriority; set => _rolePriority = value; }
    }
}
