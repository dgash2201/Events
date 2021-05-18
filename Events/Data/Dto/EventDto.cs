using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Data.Dto
{
    public class EventDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Sport { get; set; }

        public string[] Sportsmen { get; set; }

        public string[] Judges { get; set; }
    }
}
