using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseEnroll.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Student>()
            .HasMany(s => s.Enrollments)
            .WithOne()
            .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Course>()
            .HasMany(s => s.Enrollments)
            .WithOne()
            .HasForeignKey(e => e.CourseId);
        }
    }
}