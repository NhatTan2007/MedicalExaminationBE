using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Account;
using MedicalExamination.Domain.Responses.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalExamination.API.Controllers
{
    [EnableCors("AllowAllPolicy")]
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
                var response = await _accountService.Login(request);
                if (response != null)
                {
                    var cookieOptions = new CookieOptions() { HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Domain = "https://khamskdinhky.tech",
                        Path = "/"
                    };
                    Response.Cookies.Append("X-Access-Token", response.Token, cookieOptions);
                    Response.Cookies.Append("X-Username", response.UserName, cookieOptions);
                    Response.Cookies.Append("X-Refresh-Token", response.RefreshToken, cookieOptions);

                    //test add header
                    //Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    //Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                    //Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
                    //Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");

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

            if (!(Request.Cookies.TryGetValue("X-Username", out userName) && (Request.Cookies.TryGetValue("X-Refresh-Token", out refreshToken))))
            {
                return BadRequest();
            }

            var user = _userService.GetUserByUsernameAndRefreshToken(userName, refreshToken);

            if (user == null) return BadRequest();
            //zo anh
            string token = await _tokenService.CreateToken(user);

            CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true,
                SameSite = SameSiteMode.None, Secure = true, Domain = "https://khamskdinhky.tech",
            Path="/" };
            Response.Cookies.Append("X-Access-Token", token, cookieOptions);
            Response.Cookies.Append("X-Username", user.UserName, cookieOptions);
            Response.Cookies.Append("X-Refresh-Token", user.RefreshToken, cookieOptions);
            return Ok();
        }
    }
}
