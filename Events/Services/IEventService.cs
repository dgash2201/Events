using System.Threading.Tasks;
using Events.Data.Dto;
using Events.Data.Models;

namespace Events.Services
{
    public interface IEventService
    {
        Task<EventDto> Get(string id);

        Task<string> Create(EventDto obj);

        Task Update(EventDto obj);

        Task Delete(string id);
    }
}
