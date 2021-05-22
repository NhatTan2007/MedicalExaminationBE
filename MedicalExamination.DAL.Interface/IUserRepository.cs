using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.User;
using MedicalExamination.Domain.Responses.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Interface
{
    public interface IUserRepository
    {
        Task<CreateUserRes> CreateNewUser(AppIdentityUser newUser, string password);
        List<UserViewModel> GetAllUser();
        Task<AppIdentityUser> GetUserById(string userId);
        int CountEmployees();
        Task<UpdateUserRes> UpdateUserInfo(AppIdentityUser user);
        AppIdentityUser GetUserByUsernameAndRefreshToken(string username, string refreshToken);
        Task<AppIdentityUser> GetUserInfo(string userName);
    }
}
