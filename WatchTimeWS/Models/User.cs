using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WatchTimeWS.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique=true)]
        [StringLength(40)]
        public string Login { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(40)]
        [EmailAddress()]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public long ToWatchTime { get; set; }
        public long WatchedTime { get; set; }
    }
}