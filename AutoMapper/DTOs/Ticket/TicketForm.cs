using System;
using System.ComponentModel.DataAnnotations;
namespace UrbanFiesta.AutoMapper.DTOs.Ticket
{
    public class TicketForm
    {
        [Required]
        public string name { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
    }
}