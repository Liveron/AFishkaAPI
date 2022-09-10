using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFishka.Application.Events.Queries.GetEventList
{
    public class EventListVm
    {
        public IList<EventListDto> Events { get; set; }
    }
}
