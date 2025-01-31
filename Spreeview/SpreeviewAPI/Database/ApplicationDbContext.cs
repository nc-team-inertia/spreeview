using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpreeviewAPI.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int> // use integer based primary key
    {


        //Dependency inject env and user secrets to isolate and decouple
        private IWebHostEnvironment env;
        private IConfiguration config;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env, IConfiguration config) : base(options)
        {
            this.env = env;
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (env.IsDevelopment())
            {
                var conStr = config.GetConnectionString("ApplicationDb") ?? throw new Exception("Missing Dev Db from UserSecrets 'ApplicationDb' - add to restore functionality");
                options.UseSqlServer(conStr);
            }
        }
    }
}
