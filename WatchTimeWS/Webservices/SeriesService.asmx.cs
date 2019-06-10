using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;
using WatchTimeWS.Models;

namespace WatchTimeWS
{

    [WebService(Namespace = "http://tempuri.org/Series", Name ="WatchTime Series Web Service")]
    public class SeriesService : System.Web.Services.WebService
    {

        private EfDbContext _context;

        public SeriesService()
        {
            _context = new EfDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [WebMethod]
        public Series GetSeriesById(int id)
        {
            var series = _context.Series.SingleOrDefault(s => s.Id == id);
            return series;
        }

        [WebMethod]
        public Series GetSeriesByName(string name)
        {
            var series = _context.Series.SingleOrDefault(s => s.Name == name);
            return series;
        }

        [WebMethod]
        public List<Series> GetSeriesByNumber(int seriesNumber)
        {
            var series = _context.Series.Include(g => g.Genres).OrderBy(s => Guid.NewGuid()).Take(seriesNumber).ToList();
            return series;
        }

        [WebMethod]
        public List<Series> GetAllSeries()
        {
            var series = _context.Series.Include(g => g.Genres).ToList();
            return series;
        }

        [WebMethod]
        public List<Series> GetSeriesByQuery(string query)
        {
            var series = _context.Series.Include(g => g.Genres).Where(s => s.Name.Contains(query)).ToList();
            if (series.Count != 0)
            {
                return series;
            }
            else
            {
                return new List<Series>
                {
                    new Series()
                    {
                        YearOfProduction = 100
                    }
                };
            }
        }

        [WebMethod]
        public Producer GetProducerById(int id)
        {
            var producer = _context.Producers.SingleOrDefault(p => p.Id == id);
            return producer;
        }

        [WebMethod]
        public List<Producer> GetProducersByNumber(int producersNumber)
        {
            var producers = _context.Producers.OrderBy(s => Guid.NewGuid()).Take(producersNumber).ToList();
            return producers;
        }

        [WebMethod]
        public Producer GetProducerWithSeriesById(int id)
        {
            var producer = _context.Producers.Include(s => s.Series).SingleOrDefault(p => p.Id == id);
            return producer;
        }

        //[WebMethod]
        //public Producer GetProducerBySeriesId(int id)
        //{
        //    var producer = _context.Series.Where(s => s.Producer.Id == id);
        //}

        [WebMethod]
        public List<Producer> GetAllProducers()
        {
            var producers = _context.Producers.ToList();
            return producers;
        }

        [WebMethod]
        public List<Producer> GetProducersByQuery(string query)
        {
            var producers = _context.Producers.Where(p => p.Name.Contains(query)).ToList();
            if (producers.Count != 0)
            {
                return producers;
            }
            else
            {
                return new List<Producer>
                {
                    new Producer()
                    {
                        YearOfEstablishment = 100
                    }
                };
            }
        }

        [WebMethod]
        public int IsToWatchSeries(int id, int userId)
        {
            var toWatchSeries = _context.FavouriteSeries.SingleOrDefault(f => f.SeriesId == id && f.UserId == userId);
            if (toWatchSeries != null)
                return 1;
            else
                return 0;
        }


        [WebMethod]
        public int ToWatchSeries(bool isToWatch, int seriesId, int userId)
        {
            var series = _context.Series.SingleOrDefault(s => s.Id == seriesId);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            var userTime = TimeSpan.FromTicks(user.ToWatchTime);
            var seriesTime = TimeSpan.FromTicks(series.Time);

            if (isToWatch)
            {
                var favouriteSeries = new FavouriteSeries()
                {
                    SeriesId = seriesId,
                    UserId = userId
                };
                var fav = _context.FavouriteSeries.SingleOrDefault(f => f.SeriesId == seriesId && f.UserId == userId);
                if (fav == null)
                {
                    user.ToWatchTime = userTime.Ticks + seriesTime.Ticks;
                    _context.FavouriteSeries.Add(favouriteSeries);
                    _context.SaveChanges();
                }
                return 1;
            }
            else
            {
                var favouriteSeries = _context.FavouriteSeries.SingleOrDefault(f => f.SeriesId == seriesId && f.UserId == userId);
                if(favouriteSeries != null)
                {
                    user.ToWatchTime = userTime.Ticks - seriesTime.Ticks;
                    _context.FavouriteSeries.Remove(favouriteSeries);
                    _context.SaveChanges();
                }
                return 0;
            }
        }

        [WebMethod]
        public int IsWatchedSeries(int id, int userId)
        {
            var watched = _context.WatchedSeries.SingleOrDefault(f => f.SeriesId == id && f.UserId == userId);
            if (watched != null)
                return 1;
            else
                return 0;
        }


        [WebMethod]
        public int WatchedSeries(bool isWatched, int seriesId, int userId)
        {
            var series = _context.Series.SingleOrDefault(s => s.Id == seriesId);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            var userTime = TimeSpan.FromTicks(user.WatchedTime);
            var seriesTime = TimeSpan.FromTicks(series.Time);

            if (isWatched)
            {
                var watchedSeries = new WatchedSeries()
                {
                    SeriesId = seriesId,
                    UserId = userId
                };
                var watched = _context.WatchedSeries.SingleOrDefault(f => f.SeriesId == seriesId && f.UserId == userId);
                if (watched == null)
                {
                    user.WatchedTime = userTime.Ticks + seriesTime.Ticks;
                    _context.WatchedSeries.Add(watchedSeries);
                    _context.SaveChanges();
                }
                return 1;
            }
            else
            {
                var watchedSeries = _context.WatchedSeries.SingleOrDefault(f => f.SeriesId == seriesId && f.UserId == userId);
                if (watchedSeries != null)
                {
                    user.WatchedTime = userTime.Ticks - seriesTime.Ticks;
                    _context.WatchedSeries.Remove(watchedSeries);
                    _context.SaveChanges();
                }
                return 0;
            }
        }

        [WebMethod]
        public int IsFavouriteProducer(int id, int userId)
        {
            var favouriteProducer = _context.FavouriteProducers.SingleOrDefault(f => f.ProducerId == id && f.UserId == userId);
            if (favouriteProducer != null)
                return 1;
            else
                return 0;
        }


        [WebMethod]
        public int LikeOrUnlikeProducer(bool isFavourite, int producerId, int userId)
        {
            if (isFavourite)
            {
                var favouriteProducer = new FavouriteProducer()
                {
                    ProducerId = producerId,
                    UserId = userId
                };
                var fav = _context.FavouriteProducers.SingleOrDefault(f => f.ProducerId == producerId && f.UserId == userId);
                if (fav == null)
                {
                    _context.FavouriteProducers.Add(favouriteProducer);
                    _context.SaveChanges();
                }
                return 1;
            }
            else
            {
                var favouriteProducer = _context.FavouriteProducers.SingleOrDefault(f => f.ProducerId == producerId && f.UserId == userId);
                if (favouriteProducer != null)
                {
                    _context.FavouriteProducers.Remove(favouriteProducer);
                    _context.SaveChanges();
                }
                return 0;
            }
        }
    }
}
