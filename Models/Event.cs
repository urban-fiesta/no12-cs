using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrbanFiesta.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime start { get; set; }
        [Required]
        public DateTime finish { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string local { get; set; }
        [Required]
        public float price { get; set; }
        public string tag { get; set; }
        public string description { get; set; }
        public int ageLimit { get; set; }
        public string eventPhoto { get; set; }
    }
}