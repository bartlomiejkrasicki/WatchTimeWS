using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class FavouriteSeries
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int UserId { get; set; }
    }
}