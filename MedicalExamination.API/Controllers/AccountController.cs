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
        private UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppIdentityUser> userManager,
                                    SignInManager<AppIdentityUser> signInManager,
                                    ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginReq request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
                if (loginResult.Succeeded)
                {
                    return Ok(new AccountLoginRes() 
                                            {
                                                UserName = user.UserName,
                                                Token = _tokenService.CreateToken(user)
                                            });
                }
            }
            return Unauthorized("Invalid username or password, please try again");
        }
    }
}
