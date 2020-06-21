using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanFiesta.Models;

namespace UrbanFiesta.Data.Interfaces
{
    public interface IEventRepo
    {
        Task<IEnumerable<Event>> GetEvents(Options opts);
        Task<Event> GetEventById(int id);
        Task<Event> CreateEvent(Event evt);
        void UpdateEvent(Event evt);
        Task<Event> DeleteEvent(int id);
    }
}