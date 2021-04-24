using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalExamination.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("api/user")]
        public IActionResult GetAllUser()
        {
            return Ok(_userServices.GetAllUser());
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response about create new User</returns>
        [HttpPost("api/user")]
        public async Task<IActionResult> CreateMedicalRecord(CreateUserReq request)
        {
            return Ok(await _userServices.CreateNewUser(request));
        }

        /// <summary>
        /// Create new Medical record
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Response about create new medical record</returns>
        [HttpGet("api/user/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            return Ok(await _userServices.GetUserById(userId));
        }
    }
}
