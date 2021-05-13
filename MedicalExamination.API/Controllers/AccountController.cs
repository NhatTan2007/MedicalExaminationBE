using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using MedicalExamination.Domain.Requests.Account;
using MedicalExamination.Domain.Responses.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountLoginReq request)
        {
            if (ModelState.IsValid)
            {
                var cookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                };
                var response = new AccountLoginRes();
                var loginResult = await _accountService.Login(request, response);
                if (loginResult != null)
                {
                    Response.Cookies.Append("X-Access-Token", loginResult.Token, cookieOptions);
                    Response.Cookies.Append("X-Username", loginResult.UserName, cookieOptions);
                    Response.Cookies.Append("X-Refresh-Token", loginResult.RefreshToken, cookieOptions);
                    return Ok(response);
                }
                Response.Cookies.Delete("X-Access-Token", cookieOptions);
                Response.Cookies.Delete("X-Username", cookieOptions);
                Response.Cookies.Delete("X-Refresh-Token", cookieOptions);
                return Unauthorized("Invalid username or password, please try again");
            }
            return BadRequest(ModelState);
        }
        [AllowAnonymous]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            };
            Response.Cookies.Delete("X-Access-Token", cookieOptions);
            Response.Cookies.Delete("X-Refresh-Token", cookieOptions);
            return Ok();
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            string userName = String.Empty;
            string refreshToken = String.Empty;

            if (!(Request.Cookies.TryGetValue("X-Username", out userName) && (Request.Cookies.TryGetValue("X-Refresh-Token", out refreshToken))))
            {
                return BadRequest();
            }

            var user = _userService.GetUserByUsernameAndRefreshToken(userName, refreshToken);

            if (user == null) return BadRequest();
            string token = await _tokenService.CreateToken(user);

            CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true,
                SameSite = SameSiteMode.None, Secure = true};
            Response.Cookies.Append("X-Access-Token", token, cookieOptions);
            Response.Cookies.Append("X-Username", user.UserName, cookieOptions);
            Response.Cookies.Append("X-Refresh-Token", user.RefreshToken, cookieOptions);
            return Ok();
        }
        [Authorize]
        [HttpGet("userInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            string userName = String.Empty;

            if (!Request.Cookies.TryGetValue("X-Username", out userName))
            {
                return BadRequest();
            }

            var userInfo = await _userService.GetUserInfo(userName);
            if(userInfo != null)
            {
                return Ok(userInfo);
            }
            return BadRequest();
        }
    }
}
