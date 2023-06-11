using API.Sistema.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value, int version = 1)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = version;
        }

        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get;private set; }


    }
}
