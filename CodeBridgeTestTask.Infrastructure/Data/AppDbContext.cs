using CodeBridgeTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTestTask.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Dog> Dogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dog>().HasData( 
                    new Dog("Neo", "red & amber", 22, 32) { Id = 1 },
                    new Dog("Jessy", "black & white", 7, 14) { Id = 2 },
                    new Dog("Donie", "black", 20, 17) { Id = 3 },
                    new Dog("Tom", "brown", 17, 25) { Id = 4 }
                );
        }
    }
}