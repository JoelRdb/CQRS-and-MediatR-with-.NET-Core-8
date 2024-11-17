using CQRS_and_MediatR.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product("iPhone16Pro", "Apple's latest flagship smartphone with a ProMotion display and improved cameras", 489.01m),
                new Product("Dell XPS 15", "Dell's high-performance laptop with a 4K InfinityEdge display", 489.01m),
                new Product("iPhone16Pro", "Sony's top-of-the-line wirelss noise-canceling headphones", 489.01m)); // Le suffixe 'm' indique que c'est un decimal.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("codewithmukesh");
        }
    }
}
