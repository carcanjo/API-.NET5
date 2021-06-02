using System.Text;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Management.ViewModel;
using Management.ViewModel.RegistrationVaccineViewModel;
using Management.ViewModel.VaccineViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.DTO;
using Services.Interfaces;
using Services.Services;
using VaccineManagement.Token;
using VaccineManagement.ViewModels;

namespace Management
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            #region JWT
            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Management Vaccine",
                    Version = "v1",
                    Description = "API construída para controle de vacinação COVID-19",
                    Contact = new OpenApiContact
                    {
                        Name = "Cleiton Arcanjo",
                        Email = "cleiton.arcanjo@outlook.com"
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });
            #endregion

            #region AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>().ReverseMap();
                cfg.CreateMap<CreatePatientViewModel, PatientDTO>().ReverseMap();
                cfg.CreateMap<UpdatePatientViewModel, PatientDTO>().ReverseMap();
                cfg.CreateMap<CreateVaccineViewModel, VaccineDTO>().ReverseMap();
                cfg.CreateMap<UpdateVaccineViewModel, VaccineDTO>().ReverseMap();
                cfg.CreateMap<CreateRegistrationViewModel, VaccineRegistrationDTO>().ReverseMap();
                cfg.CreateMap<UpdateRegistrationViewModel, VaccineRegistrationDTO>().ReverseMap();
            });
            #endregion

            #region Injeção de dependencia

            services.AddSingleton(d => Configuration);
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ManagerVaccine"]), ServiceLifetime.Transient);
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IVaccineService, VaccineService>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IVaccineRegistrationService, VaccineRegistrationService>();
            services.AddScoped<IVaccineRegistrationRepository, VaccineRegistrationRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
