using GM.Application.AppCore.Entities;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;
using GM.Application.AppCore.Interfaces;
using GM.Infrastructure.InfraCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GM.Infrastructure.InfraCore.Data
{
    // See here for extending this class:
    //   https://stackoverflow.com/a/40579369/1978840
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(ICurrentUserService currentUserService,
            DbContextOptions<ApplicationDbContext> options = null
            )
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        // TODO: OnModelCreating should be disabled for production 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // https://sigitov.de/how-to-handle-enums-in-asp-net-core-web-applications/
            //builder
            //    .Entity<GovLocation>()
            //    .Property(e => e.GovLocType)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (GovlocTypes)Enum.Parse(typeof(GovlocTypes), v));

        }

        public DbSet<Govbody> Govbodies { get; set; }
        public DbSet<GovLocation> GovLocations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<TopicDiscussion> TopicDiscussions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ElectedOfficial> ElectedOfficials { get; set; }
        public DbSet<AppointedOfficial> AppointedOfficials { get; set; }


        //// Temporary inclusion of eshoponweb DbSets during development
        //public DbSet<Basket> Baskets { get; set; }
        //public DbSet<CatalogItem> CatalogItems { get; set; }
        //public DbSet<CatalogBrand> CatalogBrands { get; set; }
        //public DbSet<CatalogType> CatalogTypes { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<BasketItem> BasketItems { get; set; }


        // If the dbset inherits from AuditEntity, save the audit info.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
