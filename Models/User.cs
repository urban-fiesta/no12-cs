using System.ComponentModel.DataAnnotations;

namespace UrbanFiesta.Models
{
    class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}