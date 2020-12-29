using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.AppCore.Entities.Meetings;
using GM.Application.AppCore.Entities.Speakers;
using GM.Application.AppCore.Entities.Topics;
using GM.Application.AppCore.Entities.GovLocations;

namespace GM.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Govbody> Govbodies { get; set; }
        DbSet<GovLocation> GovLocations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<TopicDiscussion> TopicDiscussions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Language> Languages { get; set; }


        //// Temporary inclusion of eshoponweb DbSets during development
        //public DbSet<Basket> Baskets { get; set; }
        //public DbSet<CatalogItem> CatalogItems { get; set; }
        //public DbSet<CatalogBrand> CatalogBrands { get; set; }
        //public DbSet<CatalogType> CatalogTypes { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<BasketItem> BasketItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
