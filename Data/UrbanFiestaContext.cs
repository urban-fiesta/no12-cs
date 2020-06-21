using Microsoft.EntityFrameworkCore;
using UrbanFiesta.Models;

namespace UrbanFiesta.Data
{
    public class UrbanFiestaContext : DbContext
    {
        public UrbanFiestaContext(DbContextOptions<UrbanFiestaContext> opt) 
            : base(opt)
        {
            
        }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>();
        }
    }
}