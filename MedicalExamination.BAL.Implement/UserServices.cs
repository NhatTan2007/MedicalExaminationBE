﻿using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using MedicalExamination.Domain.Requests.User;
using MedicalExamination.Domain.Responses.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Implement
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private string _employeeCodePattern;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _employeeCodePattern = "NV00000000";
        }

        public async Task<CreateUserRes> CreateNewUser(CreateUserReq request)
        {
            AppIdentityUser newUser = Helper.AutoDTO<CreateUserReq, AppIdentityUser>(request);


            //Add user id and employeeCode
            newUser.Id = new Guid().ToString();
            //Make employee code
            if (request.IsEmployee)
            {
                int employeesCount = _userRepository.CountEmployees();
                _employeeCodePattern = _employeeCodePattern.Substring(0, _employeeCodePattern.Length - employeesCount.ToString().Length - 1);
                newUser.EmployeeCode = $"{_employeeCodePattern}{employeesCount}";
            }

            return await _userRepository.CreateNewUser(newUser, request.Password);
        }

        public List<UserViewModel> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public async Task<UserDetailsModel> GetUserById(string userId)
        {
            return Helper.AutoDTO<AppIdentityUser, UserDetailsModel>(await _userRepository.GetUserById(userId));
        }
    }
}