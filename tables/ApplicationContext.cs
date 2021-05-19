using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TrainingProject.tables
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cell> cells { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Stand> stands { get; set; }
        public DbSet<StoreDepartment> storeDepartments { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreDepartment>().HasKey(u => new { u.StoreId, u.DepartmentId });
            modelBuilder.Entity<Stand>().HasKey(u => u.Id);
            modelBuilder.Entity<Cell>().HasKey(u => u.Id);
            modelBuilder.Entity<Product>().HasKey(u => u.Id);
            modelBuilder.Entity<Stand>()
                .HasOne(u => u.StoreDepartment)
                .WithMany(t => t.Stands)
                .HasForeignKey(u => new { u.StoreId, u.DepartmentId });
            modelBuilder.Entity<Cell>()
                .HasOne(u => u.Stand)
                .WithMany(t => t.Cells)
                .HasForeignKey(u => u.StandId);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.Cell)
                .WithMany(t => t.Products)
                .HasForeignKey(u => u.Cellid);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=Qwert6789");
        }
    }
}
