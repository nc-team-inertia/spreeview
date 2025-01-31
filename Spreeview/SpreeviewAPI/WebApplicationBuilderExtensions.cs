using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpreeviewAPI.Database;

namespace SpreeviewAPI
{
    public static class WebApplicationBuilderExtensions
    {
        public static void SetupDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>();
        }

        public static void SetupIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddApiEndpoints().AddEntityFrameworkStores<ApplicationDbContext>(); // build in identity classes for now
        }
    }
}
