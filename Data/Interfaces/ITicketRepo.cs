using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanFiesta.Models;

namespace UrbanFiesta.Data.Interfaces
{
    public interface ITicketRepo
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        Task<Ticket> DeleteTicket(int id);
    }
}