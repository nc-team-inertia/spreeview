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

        public ApplicationDbContext(IWebHostEnvironment env) { this.env = env; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env) : base(options)
        {
            this.env = env;
            Database.EnsureCreated(); //Ensure its created
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment env, IConfiguration config) : base(options)
        {
            this.env = env;
            this.config = config;

            Database.EnsureCreated(); //Ensure its created
        }

            //TODO test when it actually runs/is called
            //TODO in-memory option
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (env.IsDevelopment())
            {
                //TearDown + create for dev/test purposes?
                //Database.EnsureDeleted(); Database.EnsureCreated();

                string? conStr;

                if (config != null)
                {
                    Console.WriteLine("+User secrets");
                    conStr = config.GetConnectionString("ApplicationDb") ?? throw new Exception("Missing Dev Db from UserSecrets 'ApplicationDb' - add to restore functionality");
                }
                else //TODO no user secrets when update-database -- shift from user secrets into Tmp?
                {
                    Console.WriteLine("-User secrets");
                    conStr = $"Server={Tmp.Dev.Server};Database={Tmp.Dev.DbName};User Id={Tmp.Dev.User};Password={Tmp.Dev.Pass};Trust Server Certificate=True";
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

        //Purely for migration to work when decoupling to DBcontext
    public class E : IWebHostEnvironment
    {
        public string WebRootPath { get; set; } = "";
        public IFileProvider WebRootFileProvider { get; set; } = null;
        public string ApplicationName { get; set; } = "";
        public IFileProvider ContentRootFileProvider { get; set; } = null;
        public string ContentRootPath { get; set; } = "";
        public string EnvironmentName { get; set; } = "";
    }
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var c = new ApplicationDbContext(new E() { EnvironmentName = "Development" });

            return c;
        }
    }

}
