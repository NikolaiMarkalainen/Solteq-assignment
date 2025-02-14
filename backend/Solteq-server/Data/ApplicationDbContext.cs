using Microsoft.EntityFrameworkCore;
using Solteq_server.models;

namespace Solteq_server.data {
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)      
        : base(options)
      {
      }

      public DbSet<User> User { get; set;  }
      public DbSet<Product> Products { get; set; }
      public DbSet<NutritionalDetails> NutritionalDetails { get; set; }

      public DbSet<GenericProduct> GenericProducts { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<User>().ToTable("users");
         modelBuilder.Entity<GenericProduct>().ToTable("generic_products");
         modelBuilder.Entity<Product>().ToTable("products");
         modelBuilder.Entity<NutritionalDetails>().ToTable("nutritional_details");

         modelBuilder.Entity<Product>()
         .HasOne(p => p.NutritionalDetails)
         .WithOne()
         .HasForeignKey<NutritionalDetails>(nd => nd.ProductId)
         .HasPrincipalKey<Product>(p => p.Id)
         .OnDelete(DeleteBehavior.Cascade);
      }
   }
}