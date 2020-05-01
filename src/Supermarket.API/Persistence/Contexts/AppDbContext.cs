using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Supermarket.API.Domain.Models;
using System;
using System.IO;

namespace Supermarket.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { set; get; }
        public DbSet<BusyTime> BusyTimes { set; get; }

        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                var connectionString = @"Data Source=(LocalDb)\Lime;Initial Catalog=LimeCRM;Integrated Security=SSPI;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Employee>().HasKey(p => p.EmployeeIdString);
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<Employee>().HasMany(p => p.BusyTimes).WithOne(p => p.Employee).HasForeignKey(p => p.EmployeeIdString);

            
            builder.Entity<BusyTime>().ToTable("BusyTimes");
            builder.Entity<BusyTime>().Property(p => p.EmployeeIdString).IsRequired();
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingStart).HasColumnType("smalldatetime").IsRequired();
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingEnd).HasColumnType("smalldatetime").IsRequired();
            
        }
    }
}