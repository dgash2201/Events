using System.Threading.Tasks;
using AutoMapper;
using Events.Data.Models;
using Events.Data.Database;
using Events.Data.Dto;

namespace Events.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _repository;
        private IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EventDto> Get(string id)
        {
            var evt = await _repository.Get(id);
            var eventDto = _mapper.Map<EventDto>(evt);

            return eventDto;
        }

        public async Task<string> Create(EventDto evt)
        {
            var eventModel = _mapper.Map<Event>(evt);
            await _repository.Add(eventModel);

            return eventModel.Id;
        }

        public async Task Update(EventDto evt)
        {
            var eventModel = _mapper.Map<Event>(evt);
            await _repository.Update(eventModel);
        }

        public async Task Delete(string id)
        {
            await _repository.Remove(id);
        }
    }
}
