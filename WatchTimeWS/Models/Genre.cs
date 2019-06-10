using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WatchTimeWS.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [XmlIgnore]
        public Series Series { get; set; }
}
}