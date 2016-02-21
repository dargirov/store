namespace OnlineStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Joke> Jokes { get; set; }

        public IDbSet<JokeCategory> JokesCategories { get; set; }

        public IDbSet<Collection> Collections { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductVariant> ProductVariants { get; set; }

        public IDbSet<ProductImage> ProductImages { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderProduct> OrderProducts { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<City> Cities { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasRequired(c => c.ProductVariant)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
