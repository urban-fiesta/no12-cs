using System;
using System.ComponentModel.DataAnnotations;

namespace UrbanFiesta.AutoMapper.DTOs.Event
{
    public class EventCreateDto
    {
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
        public string Description { get; set; }
        public int ageLimit { get; set; }
        public string eventPhoto { get; set; }
    }
}