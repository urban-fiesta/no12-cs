using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbanFiesta.Data.Interfaces;
using UrbanFiesta.Models;

namespace UrbanFiesta.Data.Repositories
{
    public class TicketRepo  : ITicketRepo
    {

        private readonly UrbanFiestaContext _context;

        public TicketRepo(UrbanFiestaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));
            
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) throw new ArgumentNullException(nameof(ticket));

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}