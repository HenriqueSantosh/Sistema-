using API.Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Domain.Command
{
    public class UsuarioCreateCommand : Core.Commands.Command
    {
        public string CPF { get; protected set; }
        public string Nome { get; protected set; }
        public string RG { get; protected set; }
        public DateTime DataExpedicao { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public string OrGaoExpedicao { get; protected set; }
        public string Uf{ get; protected set; }
        public string Sexo { get; protected set; }
        public string EstadoCivil { get; protected set; }
        public Endereco Endereco { get; protected set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
