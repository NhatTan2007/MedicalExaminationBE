using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Account;
using MedicalExamination.Domain.Responses.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<AppIdentityUser> userManager,
                            SignInManager<AppIdentityUser> signInManager,
                            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //public async Task<string> CreateCookie(AccountLoginRes response)
        //{

        //}

        public async Task<AccountLoginRes> Login(AccountLoginReq request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (loginResult.Succeeded)
                {
                    return new AccountLoginRes()
                    {
                        UserName = user.UserName,
                        Token = await _tokenService.CreateToken(user),
                        RefreshToken = user.RefreshToken
                    };
                }
            }
            return null;
        }
    }
}
