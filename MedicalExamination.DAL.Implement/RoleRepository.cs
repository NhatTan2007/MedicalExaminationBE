using MedicalExamination.DAL.Implement.DbContexts;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Requests.Role;
using MedicalExamination.Domain.Responses.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.DAL.Implement
{
   public class RoleRepository : IRoleRepository
    {
        private RoleManager<AppIdentityRole> _roleManager;
        private AppDbContext _dbContext;

        public RoleRepository(RoleManager<AppIdentityRole> roleManager,
                              AppDbContext dbContext)
        {
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task<CreateRoleRes> CreateNewRole(CreateRoleReq newRole)                                          
        {
            CreateRoleRes response = new CreateRoleRes();
            try
            {
                AppIdentityRole appIdentityRole = new AppIdentityRole
                {
                   Name = newRole.RoleName,
                   IsActive = newRole.IsActive,
                   RolePriority = newRole.RolePriority
                };
                var result = await _roleManager.CreateAsync(appIdentityRole);
                if(result.Succeeded)
                {
                    response.RoleId = appIdentityRole.Id;
                    response.RoleName = appIdentityRole.Name;
                    response.Message = "Vai trò mới đã được tạo";
                }
                else
                {
                    response.Message = "Đã có lỗi xảy ra xin liên hệ với Quản trị hệ thống";
                    return response;
                }
                return response;

            }
            catch (Exception ex)
            {

                response.Message = "Có lỗi đã xảy ra, xin mời liên lạc Quản trị hệ thống";
                return response;
            }       
        }

        public async Task<UpdateRoleRes> UpdateRole(UpdateRoleReq updateRole)
        {
            UpdateRoleRes response = new UpdateRoleRes();
            var getRole = await _roleManager.FindByIdAsync(updateRole.RoleId);
            try
            {
                if(getRole != null)
                {
                    getRole.Name = updateRole.RoleName;
                    getRole.IsActive = updateRole.IsActive;
                    getRole.RolePriority = updateRole.RolePriority;
                    var result = await _roleManager.UpdateAsync(getRole);
                    if (result.Succeeded)
                    {
                        response.NameRole = getRole.Name;
                        response.Message = "Đã cập nhật role thành công";
                        return response;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
