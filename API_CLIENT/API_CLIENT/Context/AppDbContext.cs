using API_CLIENT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CLIENT.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nome)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(c => c.Email)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasIndex(c => c.Email)
                      .IsUnique();

            });
        }
    }
}
