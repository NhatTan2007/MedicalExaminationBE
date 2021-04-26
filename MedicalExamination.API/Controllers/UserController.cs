using MedicalExamination.BAL.Interface;
using MedicalExamination.Domain.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalExamination.API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet("")]
        public IActionResult GetAllUser()
        {
            return Ok(_userServices.GetAllUser());
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response about create new User</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateMedicalRecord(CreateUserReq request)
        {
            return Ok(await _userServices.CreateNewUser(request));
        }

        /// <summary>
        /// Get a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Specific User</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            return Ok(await _userServices.GetUserById(userId));
        }
    }
}
