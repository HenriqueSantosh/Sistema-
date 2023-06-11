using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }

        protected Event() => TimeStamp = DateTime.Now;
    }
}
