using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.FileProviders;

namespace SpreeviewAPI.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int> 
        // use integer based primary key
    {

        //Dependency inject env and user secrets to isolate and decouple
        private IWebHostEnvironment env;
        private IConfiguration config;

            //ctor for tests
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env) : base(options)
        { this.env = env; Database.EnsureCreated(); }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env, IConfiguration config) : base(options)
        {
            this.env = env; this.config = config;
            Database.EnsureCreated(); //Populates if seeding is used
        }

            //TODO test when it actually runs/is called
            //TODO in-memory option (enum options?)
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (env.IsDevelopment())
            {
                //TearDown + create for dev/test purposes?
                //Database.EnsureDeleted(); Database.EnsureCreated();

                string? conStr=null;

                if (config != null)
                {
                    Console.WriteLine("+User secrets");
                    conStr = config.GetConnectionString("ApplicationDb") ?? throw new Exception("Missing Dev Db from UserSecrets 'ApplicationDb' - add to restore functionality");
                }
                else
                {
                    Console.WriteLine("-User secrets");
                        //TODO sort into testing?
                }

                options.UseSqlServer(conStr ?? throw new InvalidDataException("No connection string for dev!"));
            }
            else if (env.IsProduction())
            {
                //running via .exe // compiled
                throw new NotImplementedException("AWS connection needed!");
            }
            else { throw new Exception("Unexpected environment!"); }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Setup values to test here!
            base.OnModelCreating(builder); //For identity superclass
        }
    }
}
