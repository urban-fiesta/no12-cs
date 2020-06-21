using System;

namespace UrbanFiesta.AutoMapper.DTOs.Event
{
    public class EventReadDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
        public DateTime date { get; set; }
        public string local { get; set; }
        public float price { get; set; }
        public string tag { get; set; }
        public string Description { get; set; }
        public int ageLimit { get; set; }
        public string eventPhoto { get; set; }
    }
}