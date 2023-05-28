using System;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infraestructure.Persistence
{
    
    public class ApplicationDbContext: DbContext
    {
      
        public DbSet<TaskDTO> TaskPersistence { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:sqlserver12.database.windows.net,1433;Initial Catalog=TaskManagement;Persist Security Info=False;User ID=kaquiroga;Password=Espe2023.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

