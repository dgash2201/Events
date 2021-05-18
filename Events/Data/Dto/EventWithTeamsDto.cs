using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Data.Dto
{
    public class EventWithTeamsDto : EventDto
    {
        public string[] Teams { get; set; }
    }
}
