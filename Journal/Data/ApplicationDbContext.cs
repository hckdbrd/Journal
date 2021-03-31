using Journal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Data
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Journal.Models.Journal> Journals { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<TeacherJournal> TeachersJournals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

            builder.Entity<Subject>()
                .HasMany(s => s.Classes)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            //The next 3 builders - ManyToMany
            builder.Entity<TeacherJournal>()
                .HasKey(tj => new { tj.JournalId, tj.TeacherId });

            builder.Entity<TeacherJournal>()
                .HasOne(tj => tj.Teacher)
                .WithMany(t => t.TeachersJournals)
                .HasForeignKey(tj => tj.TeacherId);


            builder.Entity<TeacherJournal>()
                .HasOne(tj => tj.Journal)
                .WithMany(j => j.TeachersJournals)
                .HasForeignKey(tj => tj.JournalId);


            builder.Entity<Class>()
               .HasMany(c => c.Journals)
               .WithOne(j => j.Class)
               .HasForeignKey(j => j.ClassId);

            builder.Entity<Student>()
                .HasMany(s => s.Journals)
                .WithOne(j => j.Student)
                .HasForeignKey(j => j.StudentId);

            builder.Entity<Specialization>()
                .HasMany(spec => spec.Students)
                .WithOne(st => st.Specialization)
                .HasForeignKey(st => st.SpecializationId);

            builder.Entity<Teacher>()
                .HasMany(t => t.Groups)
                .WithOne(g => g.Teacher)
                .HasForeignKey(g => g.TeacherId);
        }
    }
}

