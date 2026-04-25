using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>(); // Asumiendo que `User` es una entidad del dominio

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones si las necesitas
            base.OnModelCreating(modelBuilder);
        }
    }
}
