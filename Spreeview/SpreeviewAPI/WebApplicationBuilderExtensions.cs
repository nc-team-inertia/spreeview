using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpreeviewAPI.Database;

namespace SpreeviewAPI
{
    public static class WebApplicationBuilderExtensions
    {
        public static void SetupDbContext(this WebApplicationBuilder builder)
        {

            if (builder.Environment.IsDevelopment())
            {
                var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDb");

                if (applicationDbConnectionString == null)
                {
                    throw new InvalidOperationException("ApplicationDb connection string not found. Please include this in usersecrets for development purposes.");
                }

                builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(applicationDbConnectionString));
            }
            else if (builder.Environment.IsProduction()) {

                var connection = ProdSecret.ProdCon ?? throw new Exception("Missing ProductString!");

                Console.WriteLine(connection);
                throw new NotImplementedException("Connect to prod db!");                
            }
            else
            {
                throw new Exception("Env error!");
            }
        }

        public static void SetupIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddApiEndpoints().AddEntityFrameworkStores<ApplicationDbContext>(); // build in identity classes for now
        }
    }
}
