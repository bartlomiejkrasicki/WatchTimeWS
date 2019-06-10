using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WatchTimeWS.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int SeasonsNumber { get; set; }
        [Required]
        public int YearOfProduction { get; set; }
        [Required]
        public long Time { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [StringLength(600)]
        public string ImageUrl { get; set; }
        [XmlElement("Genre")]
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
        [XmlIgnore]
        public Producer Producer { get; set; }
    }
}