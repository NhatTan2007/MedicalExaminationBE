using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.BAL.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppIdentityUser user);
    }
}
