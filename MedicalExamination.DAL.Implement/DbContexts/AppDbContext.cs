using MedicalExamination.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.DAL.Implement.DbContexts
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {

        }

        DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //seed user administrator account
            builder.Entity<AppIdentityRole>().HasData(new List<AppIdentityRole>
            {
                new AppIdentityRole()
                {
                    Id = "8dd36636-b4d8-4010-8594-caebfbe55991",
                    Name = "Quản trị viên hệ thống",
                    NormalizedName = "QUẢN TRỊ VIÊN HỆ THỐNG",
                    IsActive = true,
                    RolePriority = 1
                }
            });

            var hasher = new PasswordHasher<AppIdentityUser>();

            builder.Entity<AppIdentityUser>().HasData(
                new AppIdentityUser
                {
                    Id = "84572bc3-25fc-4ef8-9056-67c4da04069b",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FirstName = "Administrator",
                    LastName = "System",
                    Avatar = "noavatar.png",
                    IsActive = true,
                    PasswordHash = hasher.HashPassword(null, "Lovelykid1@"),
                    Signature = "",
                    PhoneNumber = "0911345992",
                    PhoneNumberConfirmed = true
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8dd36636-b4d8-4010-8594-caebfbe55991",
                    UserId = "84572bc3-25fc-4ef8-9056-67c4da04069b"
                }
                );
        }
    }
}
