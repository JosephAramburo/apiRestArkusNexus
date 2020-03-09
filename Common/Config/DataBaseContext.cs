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

        public DbSet<EmployerFiltersResult> EmployerFiltersResults { get; set; }

        public DbSet<EmployerDTO> Employer { get; set; }
        //public DbSet<EmployerFiltersResponse> EmployerResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployerDTO>().T("Employer");
            //modelBuilder.Entity<EmployerDTO>();

            //modelBuilder.Query<EmployerDTO>();
        }
    }
}
