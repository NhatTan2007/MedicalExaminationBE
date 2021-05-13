using MedicalExamination.BAL.Interface;
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
    public class UserServices : IUserService
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
            newUser.UserName = newUser.UserName.ToLower();
            //Add user id and employeeCode
            newUser.Id = Guid.NewGuid().ToString();
            //Make employee code
            if (request.IsEmployee)
            {
                int employeesCount = _userRepository.CountEmployees();
                _employeeCodePattern = _employeeCodePattern.Substring(0, _employeeCodePattern.Length - (employeesCount + 1).ToString().Length);
                newUser.EmployeeCode = $"{_employeeCodePattern}{employeesCount + 1}";
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

        public AppIdentityUser GetUserByUsernameAndRefreshToken(string username, string refreshToken)
        {
            return _userRepository.GetUserByUsernameAndRefreshToken(username, refreshToken);
        }

        public async Task<UserInfoRes> GetUserInfo(string userName)
        {
            var user = await _userRepository.GetUserInfo(userName);
            if (user != null)
            {
                return Helper.AutoDTO<AppIdentityUser, UserInfoRes>(user);
            }
            return null;
        }
    }
}
