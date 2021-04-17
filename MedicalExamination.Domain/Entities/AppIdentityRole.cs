using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Entities
{
    public class AppIdentityRole : IdentityRole
    {
        private bool _isActive;
        private byte _rolePriority;

        public bool IsActive { get => _isActive; set => _isActive = value; }
        public byte RolePriority { get => _rolePriority; set => _rolePriority = value; }

        public AppIdentityRole()
        {
            _isActive = true;
        }
    }
}
