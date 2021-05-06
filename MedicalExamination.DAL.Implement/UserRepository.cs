using MedicalExamination.DAL.Implement.DbContexts;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using MedicalExamination.Domain.Requests.User;
using MedicalExamination.Domain.Responses.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly AppDbContext _dbContext;

        public UserRepository(UserManager<AppIdentityUser> userManager,
                                AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public int CountEmployees()
        {
            return _dbContext.Users.Where(u => u.EmployeeCode != null).Count();
        }

        public async Task<CreateUserRes> CreateNewUser(AppIdentityUser newUser, string password)
        {
            newUser.DepartmentId = newUser.DepartmentId == "" ? null : newUser.DepartmentId;
            var result = await _userManager.CreateAsync(newUser, password);
            CreateUserRes response = new CreateUserRes();
            if (result.Succeeded)
            {
                response.UserId = newUser.Id;
                response.Message = "Tài khoản mới đã được tạo";
            }
            else response.Message = "Có lỗi đã xảy ra, xin mời liên lạc Quản trị hệ thống";
            return response;
        }

        public List<UserViewModel> GetAllUser()
        {
            return (from u in _dbContext.Users
                    join d in _dbContext.Departments
                    on u.DepartmentId equals d.DepartmentId into gj
                    from x in gj.DefaultIfEmpty()
                    select new UserViewModel()
                    {
                        UserId = u.Id,
                        EmployeeCode = u.EmployeeCode,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        DepartmentId = u.DepartmentId,
                        IsActive = u.IsActive,
                        DepartmentName = (x == null ? "" : x.DepartmentName)
                    }).OrderBy(u => u.DepartmentName).ToList();
        }

        public async Task<AppIdentityUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public AppIdentityUser GetUserByUsernameAndRefreshToken(string username, string refreshToken)
        {
            return _userManager.Users.FirstOrDefault(u => u.UserName == username && u.RefreshToken == refreshToken);
        }

        public Task<UpdateUserRes> UpdateUserInfo(AppIdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
