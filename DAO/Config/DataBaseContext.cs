using Common.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO.Config
{
    public class DataBaseContext : DbContext
    {
        protected string ConnectionString { get; set; }

        public DataBaseContext()
        {

        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<EmployerDTO> Employer { get; set; }
    }
}
