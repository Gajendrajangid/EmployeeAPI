using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeAPI.Concrete
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<EmployeeMaster> EmployeeMasters { set; get; }
    }
}
