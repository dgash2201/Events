using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Data.Models;

namespace Events.Data.Database
{
    public interface IEventRepository
    {
        Task<Event> Get(string id);
        Task<IEnumerable<Event>> GetAll();

        Task<string> Add(Event evt);

        Task Remove(string id);

        Task Update(Event evt);
    }
}
