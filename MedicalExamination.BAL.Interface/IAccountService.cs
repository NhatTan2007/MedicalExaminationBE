using MedicalExamination.Domain.Requests.Account;
using MedicalExamination.Domain.Responses.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IAccountService
    {
        Task<AccountLoginResult> Login(AccountLoginReq request, AccountLoginRes response);
        //Task<string> CreateCookie(AccountLoginRes response);
    }
}
