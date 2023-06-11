using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Command
{
    public class UsuarioDeleteCommand : Core.Commands.Command
    {
        public UsuarioDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
