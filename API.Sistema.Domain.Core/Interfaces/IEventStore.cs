using API.Sistema.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
