using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class FavouriteProducer
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public int UserId { get; set; }
    }
}