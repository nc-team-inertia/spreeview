using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpreeviewAPI.Database;

namespace SpreeviewAPI
{
    public static class WebApplicationBuilderExtensions
    {
        public static void SetupDbContext(this WebApplicationBuilder builder)
        {
            var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDb");

            if (applicationDbConnectionString == null)
            {
                throw new InvalidOperationException("ApplicationDb connection string not found. Please include this in usersecrets for development purposes.");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationDbConnectionString));
        }

        public static void SetupIdentity(this WebApplicationBuilder builder)
        {
            // establish cookie authentication
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme);
            
            // configure authorization
            builder.Services.AddAuthorizationBuilder();
            
            // builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddApiEndpoints().AddEntityFrameworkStores<ApplicationDbContext>(); // build in identity classes for now
            builder.Services
                .AddIdentityCore<IdentityUser<int>>()
                .AddRoles<IdentityRole<int>>()
                .AddApiEndpoints()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
        
        public static void SetupCors(this WebApplicationBuilder builder)
        {
            // Setup CORS between frontend and backend
            string? backendUrl = builder.Configuration["BackendUrl"];
            string? frontendUrl = builder.Configuration["FrontendUrl"];

            if (backendUrl == null)
            {
                throw new InvalidOperationException("BackendUrl is missing from configuration.");
            }

            if (frontendUrl == null)
            {
                throw new InvalidOperationException("FrontendUrl URL is missing from configuration.");
            }
            
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(backendUrl, frontendUrl)
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
