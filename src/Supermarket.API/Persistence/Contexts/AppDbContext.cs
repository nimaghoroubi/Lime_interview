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
            builder.Entity<Employee>().Property(p => p.EmployeeName).IsRequired();
            builder.Entity<Employee>().HasMany(p => p.BusyTimes).WithOne(p => p.Employee).HasForeignKey(p => p.EmployeeIdString);

            builder.Entity<Employee>().HasData
                (
                    new Employee { Id = 1, EmployeeIdString = "11111111",
                        EmployeeName = "Jack Daniels" }, // Id set manually due to in-memory provider

                    new Employee {Id = 2, EmployeeIdString = "11111112",
                        EmployeeName = "Mike Tyson" }, // Id set manually due to in-memory provider
                    
                    new Employee {Id = 3, EmployeeIdString = "11111113",
                        EmployeeName = "Mike Tyson" } // Id set manually due to in-memory provider
                );

            builder.Entity<BusyTime>().HasData
                (
                    new BusyTime {Id=1, EmployeeIdString = "11111111",
                        EmployeeMeetingStart = DateTime.Parse("05/29/2015 5:00 AM"),
                        EmployeeMeetingEnd = DateTime.Parse("05/29/2015 6:0 AM") }, // Id set manually due to in-memory provider

                    new BusyTime {Id=2, EmployeeIdString = "11111111", 
                        EmployeeMeetingStart = DateTime.Parse("05/29/2015 7:00 AM"), 
                        EmployeeMeetingEnd = DateTime.Parse("05/29/2015 8:0 AM") }, // Id set manually due to in-memory provider

                    new BusyTime {Id=3, EmployeeIdString = "11111112", 
                        EmployeeMeetingStart = DateTime.Parse("05/29/2015 7:00 AM"), 
                        EmployeeMeetingEnd = DateTime.Parse("05/29/2015 8:0 AM") },// Id set manually due to in-memory provider

                    new BusyTime{
                        Id = 4,
                        EmployeeIdString = "11111113",
                        EmployeeMeetingStart = DateTime.Parse("05/29/2015 7:00 PM"),
                        EmployeeMeetingEnd = DateTime.Parse("05/29/2015 8:00 PM")
                    }// Id set manually due to in-memory provider
                );

            builder.Entity<BusyTime>().ToTable("BusyTimes");
            builder.Entity<BusyTime>().Property(p => p.EmployeeIdString);
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingStart).HasColumnType("smalldatetime").IsRequired();
            builder.Entity<BusyTime>().Property(p => p.EmployeeMeetingEnd).HasColumnType("smalldatetime").IsRequired();
            
        }
    }
}