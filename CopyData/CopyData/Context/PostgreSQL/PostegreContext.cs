using CopyData.Mapping.PostgreSQL;
using CopyData.Models.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace CopyData.Context.PostgreSQL
{
    public class PostegreContext : DbContext
    {
        public PostegreContext()
        {
                
        }
        public DbSet<Contato> contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=cadastros;User Id=postgres;Password=12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
