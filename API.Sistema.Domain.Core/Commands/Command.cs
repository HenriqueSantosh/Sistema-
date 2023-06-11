using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;
using API.Sistema.Domain.Core.Events;

namespace API.Sistema.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        protected Command() => Timestamp = DateTime.Now;

        public abstract bool IsValid();
    }
}
