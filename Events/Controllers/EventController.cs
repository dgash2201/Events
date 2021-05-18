using System;
using System.IO;
using System.Threading.Tasks;
using Events.Data.Dto;
using Events.Data.Models;
using Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [Route("Events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Получение мероприятия по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор мероприятия.</param>
        /// <returns>Модель мероприятия.</returns>
        [HttpGet]
        [Route(nameof(Get))]
        public async Task<IActionResult> Get(string id)
        {
            var evt = await _eventService.Get(id);
            return Ok(new { Success = true, Event = evt });
        }

        /// <summary>
        /// Добавление мероприятия.
        /// </summary>
        /// <param name="evt">Модель для добавления.</param>
        /// <returns>Идентификатор добавленного мероприятия.</returns>
        [HttpPost]
        [Route(nameof(Create))]
        [Produces("application/json")]
        public async Task<IActionResult> Create(EventDto evt)
        {
            return Ok(new { Success = true, EventId = await _eventService.Create(evt) });
        }

        /// <summary>
        /// Обновление мероприятия.
        /// </summary>
        /// <param name="evt">Модель для обновления.</param>
        /// <returns>Идентификатор обновленной мероприятия.</returns>
        [HttpPost]
        [Route(nameof(Update))]
        [Produces("application/json")]
        public async Task<IActionResult> Update(EventDto evt)
        {
            await _eventService.Update(evt);

            return Ok(new { Success = true });
        }

        /// <summary>
        /// Удаление мероприятия.
        /// </summary>
        /// <param name="id">Модель для удаления.</param>
        /// <returns>Идентификатор обновленной мероприятия.</returns>
        [HttpPost]
        [Route(nameof(Delete))]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.Delete(id);

            return Ok(new { Success = true });
        }
    }
}