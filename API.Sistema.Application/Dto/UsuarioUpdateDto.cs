using System;
using System.Collections.Generic;
using System.Text;

namespace API.Sistema.Application.Dto
{
    public class UsuarioUpdateDto
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime DataExpedicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string OrGaoExpedicao { get; set; }
        public string UF { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
