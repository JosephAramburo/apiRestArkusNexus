using Common.DTO;
using Microsoft.EntityFrameworkCore;

namespace Common.Config
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {

        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<EmployerDTO> Employer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployerDTO>().T("Employer");
            //modelBuilder.Entity<EmployerDTO>();

            //modelBuilder.Query<EmployerDTO>();
        }
    }
}
