using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class EfDbContext : DbContext
    {
        public DbSet<Series> Series { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<FavouriteSeries> FavouriteSeries { get; set; }
        public DbSet<FavouriteProducer> FavouriteProducers { get; set; }
        public DbSet<WatchedSeries> WatchedSeries { get; set; }
        public DbSet<Season> Seasons { get; set; }
    }
}