using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Assignment02.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment02.DbContexts
{
    class ITIDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<StudCourse> StudCourses { get; set; }
        public DbSet<CourseInst> CourseInstructors { get; set; }

        public ITIDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = ITI; Trusted_Connection = true; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                        .HasOne(D => D.Department)
                        .WithMany(S => S.Students)
                        .HasForeignKey(D => D.Dep_Id);

            modelBuilder.Entity<Instructor>()
                        .HasOne(D => D.Departments)
                        .WithMany(I => I.Instructors)
                        .HasForeignKey(D => D.Dept_ID);

            modelBuilder.Entity<Course>()
                        .HasOne(T => T.Topics)
                        .WithMany(C => C.Courses)
                        .HasForeignKey(T => T.Top_ID);

            //Unable to create a 'DbContext' of type 'ITIDbContext'.
            //The exception 'The entity type 'CourseInst' requires a primary key to be defined.
            //If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.
            //For more information on keyless entity types

            modelBuilder.Entity<StudCourse>()
                        .HasKey(S => new { S.Stud_ID, S.Course_ID });

            modelBuilder.Entity<CourseInst>()
                        .HasKey(I => new { I.Inst_ID, I.Course_ID });
        }

    }
}