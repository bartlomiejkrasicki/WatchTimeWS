using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class Season
    {
        public int Id { get; set; }
        [Required]
        public int SeasonNumber { get; set; }
        public TimeSpan TimeOfDuration { get; set; }
        public Series Series { get; set; }
    }
}