using System;
using System.Linq;
using System.Web.Services;
using WatchTimeWS.Models;

namespace WatchTimeWS
{

    [WebService(Namespace = "http://tempuri.org/TimeService", Name = "WatchTime Time Web Service")]
    public class TimeService : System.Web.Services.WebService
    {

        private EfDbContext _context;

        public TimeService()
        {
            _context = new EfDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [WebMethod]
        public string GetToWatchTimeByUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var time = TimeSpan.FromTicks(user.ToWatchTime);
            
            return time.Days + " days " + time.Hours + " hours " + time.Minutes + " minutes";
        }

        [WebMethod]
        public string GetWatchedTimeByUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var time = TimeSpan.FromTicks(user.WatchedTime);

            return time.Days + " days " + time.Hours + " hours " + time.Minutes + " minutes";
        }

    }
}
