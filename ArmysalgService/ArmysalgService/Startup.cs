using ArmysalgDataAccess.Security;
using ArmysalgService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ArmysalgService
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
            SymmetricSecurityKey SIGNING_KEY = new SecurityHelper(Configuration).GetSecurityKey();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SIGNING_KEY,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(3)
                };
            });

            services.AddControllers();

            services.AddDbContext<ArmysalgServiceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ArmysalgServiceContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
