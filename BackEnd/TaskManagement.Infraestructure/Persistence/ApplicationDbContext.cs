using System;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infraestructure.Persistence
{
    
    public class ApplicationDbContext: DbContext
    {
      
        public DbSet<TaskDTO> TaskPersistence { get; set; }

       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskDTO>(entity =>
            {
                entity.ToTable("Task");
                entity.HasKey(t => t.IdTask);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Description).IsRequired().HasMaxLength(500);
                entity.Property(t => t.State).IsRequired().HasConversion<string>();
                entity.Property(t => t.CreateDate).IsRequired().HasConversion<DateTime>();
            });
        }
    }
}

