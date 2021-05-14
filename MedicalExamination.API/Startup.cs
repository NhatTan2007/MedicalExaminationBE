using MedicalExamination.API.Controllers;
using MedicalExamination.BAL.Implement;
using MedicalExamination.BAL.Interface;
using MedicalExamination.DAL.Implement;
using MedicalExamination.DAL.Implement.DbContexts;
using MedicalExamination.DAL.Interface;
using MedicalExamination.Domain.Entities;
using MedicalExamination.Domain.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private string _corsPolicy = "AllowAllPolicy";

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.WithOrigins(Helper.domain, "http://khamskdinhky.tech:4200");
            corsBuilder.AllowCredentials();

            services.AddCors(opts => {
                opts.AddPolicy(_corsPolicy, corsBuilder.Build());
            });
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(_config.GetConnectionString("DbConnection")), ServiceLifetime.Transient);

            services.AddIdentity<AppIdentityUser, AppIdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            })
                            .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    opts.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                            {
                                context.Token = context.Request.Cookies["X-Access-Token"];
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddControllers().AddNewtonsoftJson();

            // chan multi-part
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "Medical Examination Api",
                            Version = "v1"
                        }
                     );

                    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MedicalExamination.API.xml");
                    c.IncludeXmlComments(filePath);
                });


            services.AddScoped<IOrganizationsRepository, OrganizationsRepository>();
            services.AddScoped<IOrganizationsService, OrganizationsService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerServices>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IGMExaminationRepository, GMExaminationRepository>();
            services.AddScoped<IGMExaminationService, GMExaminationService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentServices>();
            services.AddScoped<ICustomerOrganizationRepository, CustomerOrganizationRepository>();
            services.AddScoped<ICustomerOrganizationService, CustomerOrganizationService>();
            services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();
            services.AddScoped<IMedicalServiceService, MedicalServiceService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(_corsPolicy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Examination API");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseHttpsRedirection();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
