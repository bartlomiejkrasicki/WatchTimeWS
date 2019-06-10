using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class Producer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(600)]
        public string ImageUrl { get; set; }
        [Required]
        public int YearOfEstablishment { get; set; }
        public List<Series> Series { get; set; }
    }
}