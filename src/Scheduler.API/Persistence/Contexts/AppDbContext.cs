using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Supermarket.API.Domain.Models;
using System;
using System.IO;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    // creates the db context for the two tables, employee and busytimes, 
    // employee has a foreign key that connects to records in busytime
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { set; get; }
        public DbSet<BusyTime> BusyTimes { set; get; }

        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // configures sql server
                var connectionString = @"Data Source=(LocalDb)\Lime;Initial Catalog=LimeCRM;Integrated Security=SSPI;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // designs the table, the primary key is EmployeeIdString
            // table name is Employee and the foreign key is set here, linking employee.EmployeeIdString to the busytimes table
            builder.Entity<Employee>().HasKey(p => p.EmployeeIdString);
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<Employee>().HasMany(p => p.BusyTimes).WithOne(p => p.Employee).HasForeignKey(p => p.EmployeeIdString);

            // creates the busytimes table, has employeeId, start of meeting and end of meeting
            builder.Entity<BusyTime>().ToTable("BusyTimes");
            builder.Entity<BusyTime>().Property(p => p.EmployeeIdString).IsRequired();
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingStart).HasColumnType("smalldatetime").IsRequired();
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingEnd).HasColumnType("smalldatetime").IsRequired();
            
        }
    }
}