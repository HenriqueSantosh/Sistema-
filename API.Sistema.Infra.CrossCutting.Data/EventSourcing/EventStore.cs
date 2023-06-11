using API.Sistema.Domain.Core.Events;
using API.Sistema.Domain.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Infra.CrossCutting.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);
            var storedEvent = new StoredEvent(theEvent, serializedData, "_user.Name");
        }
    }
}
