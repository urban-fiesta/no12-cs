using System;
using System.ComponentModel.DataAnnotations;
namespace UrbanFiesta.Models
{
    public class Ticket
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public DateTime time { get; set; }
        
    }
}