using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Account;
using MedicalExamination.Domain.Responses.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginReq request)
        {
            var result = await _accountService.Login(request);
            if (result != null)
            {
                return Ok(await _accountService.Login(request));
            }
            return Unauthorized("Invalid username or password, please try again");
        }
    }
}
