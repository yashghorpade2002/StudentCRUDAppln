using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CRUD.EF.Models
{
    public class CrudDbContext : DbContext
    {
        private string? connectionString;

        public CrudDbContext()
        {
            
        }
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-N4OT5H5\\SQLEXPRESS;Initial Catalog=CRUD_Students;Integrated Security=True;Trust Server Certificate=True");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        internal virtual DbSet<Student> Students { get; set; }

        internal virtual DbSet<StudentAddress> StudentAddresses { get; set; }

        internal virtual DbSet<Subject> Subjects { get; set; }
    }
}
