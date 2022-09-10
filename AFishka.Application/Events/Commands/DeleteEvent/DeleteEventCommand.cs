using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFishka.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

    }
}
