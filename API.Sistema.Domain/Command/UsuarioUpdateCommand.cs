using System;
using System.Collections.Generic;
using System.Text;
using API.Sistema.Domain.Core.Commands;
using API.Sistema.Domain.Models;

namespace API.Sistema.Domain.Command
{
    public class UsuarioUpdateCommand : API.Sistema.Domain.Core.Commands.Command
    {
        public Guid Id { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string RG { get; private set; }
        public DateTime DataExpedicao { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string OrGaoExpedicao { get; private set; }
        public string UF { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }

        public Endereco Endereco { get; protected set; }
      

        public override bool IsValid()
        {
            return true;
        }
    }
}
