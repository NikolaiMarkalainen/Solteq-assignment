using Microsoft.EntityFrameworkCore;
using Solteq_server.models;

namespace Solteq_server.data {
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
      {
      }

      public DbSet<Product> Products { get; set; }
      public DbSet<NutritionalDetails> NutritionalDetails { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Product>()
         .HasOne(p => p.NutritionalDetails)
         .WithOne()
         .HasForeignKey<NutritionalDetails>(nd => nd.ProductId)
         .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<Product>()
         .Property(p => p.ProductContains)
         .HasConversion(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

         modelBuilder.Entity<Product>()
         .Property(p => p.ProductDoesNotContain)
         .HasConversion(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
      }
   }
}