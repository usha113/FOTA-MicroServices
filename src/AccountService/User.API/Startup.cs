using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using User.Infrastructure.Data;
using User.Infrastructure.Repositories;
using User.Core.Repositories;
using User.Core.Repositories.Base;
using User.Infrastructure.Repositories.Base;
using MediatR;
using User.Application.Handlers;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;

using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json;
using User.Core.Entities;

using User.Infrastructure.Helper;

using Microsoft.AspNetCore.HttpOverrides;


namespace User.API
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
            services.AddDbContext<UserProfileContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DataAccessPostgreSqlProvider")),ServiceLifetime.Singleton);

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(AuthenticateUserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ResetPasswordHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ForgotPasswordHandler).GetTypeInfo().Assembly);
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository),typeof(UserRepository));


            #region JWT Authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            

            services.Configure<ApplicationSettings>(appSettingsSection);
            //configure jwt authentication
            var appSettings = appSettingsSection.Get<ApplicationSettings>();
            Console.WriteLine(appSettings);
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

             #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .Build());
            });
            #endregion
             #region Email Configuration
            var emailSection = Configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(emailSection);
            var emailSettings = emailSection.Get<EmailSettings>();
            services.AddScoped<SmtpClient>((serviceProvider) =>
            {
                return new SmtpClient()
                {
                    Host = emailSettings.Host,
                    Port = int.Parse(emailSettings.Port)
                };
            });
            services.AddTransient<IEmailHelper, EmailHelper>();
            #endregion

           
            services.AddOptions();
            
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository),typeof(UserRepository));

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1",new OpenApiInfo { Title="User API",Version="v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","User API V1");
            });
        }
    }
}
