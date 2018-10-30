using BGC.School.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGC.School.EntityFramework
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<TeacherCourse> TeacherCourse { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");//.Property(a=>a.Id).ValueGeneratedNever();
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment").HasOne(a=>a.Student).WithMany(m=>m.Enrollments);
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Course).WithMany(m => m.Enrollments);

            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Office>().ToTable("Office").HasKey(m=>m.TeacherId);
            modelBuilder.Entity<TeacherCourse>().ToTable("TeacherCourse").HasKey(c=>new { c.TeacherId,c.CourseId});
            modelBuilder.Entity<Department>().ToTable("Department");

            base.OnModelCreating(modelBuilder);
        }
    }
}
