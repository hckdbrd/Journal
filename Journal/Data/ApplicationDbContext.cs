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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(g => g.StudentId);

            builder.Entity<Subject>()
                .HasMany(s => s.Classes)
                .WithOne(c => c.Subject)
                .HasForeignKey(c => c.SubjectId);

            builder.Entity<Teacher>()
                .HasMany(t => t.Journals)
                .WithOne(j => j.Teacher)
                .HasForeignKey(j => j.TeacherId);

            builder.Entity<Class>()
               .HasMany(c => c.Journals)
               .WithOne(j => j.Class)
               .HasForeignKey(j => j.ClassId);

            builder.Entity<Student>()
                .HasMany(s => s.Journals)
                .WithOne(j => j.Stundent)
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

