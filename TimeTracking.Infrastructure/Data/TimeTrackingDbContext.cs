using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Infrastructure.Entities;

namespace TimeTracking.Infrastructure.Data
{
    public class TimeTrackingDbContext : DbContext
    {
        public TimeTrackingDbContext(DbContextOptions<TimeTrackingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(p => p.ProjectCode)
                .IsUnique();

            modelBuilder.Entity<TimeEntry>()
                .Property(t => t.Hours)
                .HasPrecision(5, 2);

            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeCode = "EMP001",
                    FullName = "Haseeb Naqvi",
                    IsActive = true
                },
                new Employee
                {
                    Id = 2,
                    EmployeeCode = "EMP002",
                    FullName = "Osama Asghar",
                    IsActive = true
                }
            );

            // Seed data for Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectCode = "PRJ001",
                    Name = "Internal Tools",
                    IsActive = true
                },
                new Project
                {
                    Id = 2,
                    ProjectCode = "PRJ002",
                    Name = "Customer Portal",
                    IsActive = true
                }
            );
        }
    }
}
