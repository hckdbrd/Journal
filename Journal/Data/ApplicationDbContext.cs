using Journal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Data
{
    class ApplicationDbContext: DbContext 
    {
        DbSet<Group> Groups { get; set; }
        DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>()
                .HasOne<Group>(student => student.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(g => g.StudentId);
        }
    }
}

