using Employee.Domain;
using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Afp> Afps { get; set; }
        public DbSet<SalaryHistory> SalaryHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones y restricciones adicionales
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Afp)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AfpId);
        }
    }
}
