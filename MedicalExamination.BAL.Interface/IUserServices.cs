using MedicalExamination.Domain.Requests.User;
using MedicalExamination.Domain.Responses.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.BAL.Interface
{
    public interface IUserServices
    {
        Task<CreateUserRes> CreateNewUser(CreateUserReq request);
        List<UserViewModel> GetAllUser();
        Task<UserDetailsModel> GetUserById(string userId);
    }
}
