using MedicalExamination.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppIdentityUser user);
    }
}
