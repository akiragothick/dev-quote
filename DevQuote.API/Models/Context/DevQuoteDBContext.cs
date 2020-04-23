using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuote.API.Models.Context
{
    public class DevQuoteDBContext : DbContext
    {
        public DevQuoteDBContext(DbContextOptions<DevQuoteDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Professional> Professional { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<ProjectTypeMechanism> ProjectTypeMechanism { get; set; }
        public DbSet<AssignProject> AssignProject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("tuser");
            modelBuilder.Entity<Professional>().ToTable("tprofessional");
            modelBuilder.Entity<ProjectType>().ToTable("tprojecttype");
            modelBuilder.Entity<ProjectTypeMechanism>().ToTable("tprojecttypemechanism");
            modelBuilder.Entity<AssignProject>().ToTable("tassignproject");
        }


        // Manage console
        // Add-Migration InitialCreate
        // Update-Database
    }
}
