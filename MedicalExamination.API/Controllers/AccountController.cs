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
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                    IUserService userService,
                                    ITokenService tokenService)
        {
            _accountService = accountService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginReq request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(request);
                if (result != null)
                {
                    AccountLoginRes response = await _accountService.Login(request);
                    CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict };
                    Response.Cookies.Append("c10-Access-Token", response.Token, cookieOptions);
                    Response.Cookies.Append("c10-Username", response.UserName, cookieOptions);
                    Response.Cookies.Append("c10-Refresh-Token", response.RefreshToken, cookieOptions);
                    return Ok();
                }
                return Unauthorized("Invalid username or password, please try again");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            string userName = String.Empty;
            string refreshToken = String.Empty;

            if (!(Request.Cookies.TryGetValue("c10-Username", out userName) && (Request.Cookies.TryGetValue("c10-Refresh-Token", out refreshToken))))
            {
                return BadRequest();
            }

            var user = _userService.GetUserByUsernameAndRefreshToken(userName, refreshToken);

            if (user == null) return BadRequest();

            string token = await _tokenService.CreateToken(user);

            CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax };
            Response.Cookies.Append("c10-Access-Token", token, cookieOptions);
            Response.Cookies.Append("c10-Username", user.UserName, cookieOptions);
            Response.Cookies.Append("c10-Refresh-Token", user.RefreshToken, cookieOptions);
            return Ok();
        }
    }
}
