using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GM.ApplicationCore.Entities.GovBodies;
using GM.ApplicationCore.Entities.Meetings;
using GM.ApplicationCore.Entities.Speakers;
using GM.ApplicationCore.Entities.Topics;
using GM.DatabaseAccess.Identity;

using Microsoft.eShopWeb.ApplicationCore.Features.BasketNS;
using Microsoft.eShopWeb.ApplicationCore.Features.Catalog;
using Microsoft.eShopWeb.ApplicationCore.Features.Orders;


namespace GM.DatabaseAccess
{
    // See here for extending this class:
    //   https://stackoverflow.com/a/40579369/1978840
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options = null)
            : base(options)
        {
        }

        // TODO: OnModelCreating should be disabled for production 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<GovBody> GovBodies { get; set; }
        public DbSet<GovLocation> GovLocations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<TopicDiscussion> TopicDiscussions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Language> Languages { get; set; }



        public DbSet<Basket> Baskets { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
