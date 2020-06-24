using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbanFiesta.Data.Interfaces;
using UrbanFiesta.Models;

namespace UrbanFiesta.Data.Repositories
{
    public class EventRepo : IEventRepo
    {

        private readonly UrbanFiestaContext _context;

        public EventRepo(UrbanFiestaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event>> GetEvents(Options opts)
        {
            return await _context.Events
            .Where(x => (opts.tag == null || x.tag == opts.tag)
            && (opts.name == null || x.name.Contains(opts.name))
            // && ((opts.iniDate == null && opts.endDate == null) || x.date >= opts.iniDate && x.date <= opts.endDate)
            ).ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Event> CreateEvent(Event evt)
        {
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            
            await _context.Events.AddAsync(evt);
            await _context.SaveChangesAsync();
            return evt;
        }

        public void UpdateEvent(Event evt)
        {
            _context.Entry(evt).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task<Event> DeleteEvent(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null) throw new ArgumentNullException(nameof(evt));

            _context.Events.Remove(evt);
            await _context.SaveChangesAsync();
            return evt;
        }
    }
}